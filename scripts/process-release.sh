#!/usr/bin/env bash
set -e

ACTION="${1:-}"
PROJECT="${2:-}"

if [ -z "$ACTION" ] || [ -z "$PROJECT" ]; then
  echo "Usage: $0 <get-latest-tag|calculate-version|publish|tag-and-release> <DotnetBaseKit.Cli|DotnetBaseKit.Templates> [args...]" >&2
  exit 1
fi

PROJECT_DIR="$PROJECT"

case "$ACTION" in
  get-latest-tag)
    LATEST_TAG=$(git tag -l "${PROJECT}/v*" --sort=-v:refname | head -n 1)

    if [ -z "$LATEST_TAG" ]; then
      echo "NONE"
    else
      echo "$LATEST_TAG"
    fi
    ;;

  calculate-version)
    LATEST_TAG="${3:-NONE}"
    TYPE="${4:-}"

    if [ -z "$TYPE" ]; then
      echo "Release type is required." >&2
      exit 1
    fi

    if [ "$LATEST_TAG" = "NONE" ]; then
      echo "1.0.0"
      exit 0
    fi

    LATEST_VERSION="${LATEST_TAG#*/v}"

    if [ ! -f "./scripts/release.sh" ]; then
      echo "release.sh not found" >&2
      exit 1
    fi

    ./scripts/release.sh "$LATEST_VERSION" "$TYPE"
    ;;

  publish)
    NEXT_VERSION="${3:-}"
    NUGET_KEY="${4:-}"

    if [ -z "$NEXT_VERSION" ] || [ -z "$NUGET_KEY" ]; then
      echo "NEXT_VERSION and NUGET_KEY are required." >&2
      exit 1
    fi

    dotnet build "${PROJECT_DIR}/${PROJECT_DIR}.csproj" -c Release

    dotnet pack "${PROJECT_DIR}/${PROJECT_DIR}.csproj" \
      -c Release \
      --no-build \
      -p:PackageVersion="$NEXT_VERSION" \
      -o ./artifacts

    dotnet nuget push "./artifacts/*.nupkg" \
      --api-key "$NUGET_KEY" \
      --source "https://api.nuget.org/v3/index.json" \
      --skip-duplicate
    ;;

  tag-and-release)
    NEXT_VERSION="${3:-}"
    LATEST_TAG="${4:-NONE}"
    TAG="${PROJECT}/v${NEXT_VERSION}"
    PATH_FILTER="${PROJECT_DIR}/"

    if [ -z "$NEXT_VERSION" ]; then
      echo "NEXT_VERSION is required." >&2
      exit 1
    fi

    git config user.name "github-actions[bot]"
    git config user.email "github-actions[bot]@users.noreply.github.com"

    git tag "$TAG"
    git push origin "$TAG"

    if git rev-parse --verify "$LATEST_TAG" >/dev/null 2>&1; then
      RAW_LOGS=$(git log "$LATEST_TAG"..HEAD --format="%s" -- "$PATH_FILTER")
    else
      RAW_LOGS=$(git log --format="%s" -- "$PATH_FILTER")
    fi

    RELEASE_NOTES=$(printf '%s\n' "$RAW_LOGS" \
      | sed -E 's/^[a-z]+(\([a-z0-9_-]+\))?!?:[[:space:]]*//I' \
      | awk '{ print toupper(substr($0,1,1)) substr($0,2) }' \
      | sed 's/^/- /')

    if [ -z "$RELEASE_NOTES" ]; then
      RELEASE_NOTES="- Atualizações e melhorias no projeto $PROJECT."
    fi

    gh release create "$TAG" \
      --title "$TAG" \
      --notes "$RELEASE_NOTES"
    ;;

  *)
    echo "Unknown action: $ACTION" >&2
    exit 1
    ;;
esac