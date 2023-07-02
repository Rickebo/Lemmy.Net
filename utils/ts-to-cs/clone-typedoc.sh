#!/usr/bin/env bash
trap "exit" INT

WD="$(pwd)/wd"
DESTINATION="LemmyApi/Types"

mkdir -p $WD

DEST=$(pwd)/$DESTINATION
TYPES="$WD/types"
SCRIPT=$(pwd)/typedoc-converter.sh

echo "Setting up source types..."
docker build -f builder/Dockerfile -t lemmybuilder builder/
docker run \
  -v lemmybuilder_wd:/wd \
  -v $(pwd)/wd/types:/out \
  -v $(pwd)/setup-source.sh:/setup-source.sh \
  -it lemmybuilder /bin/bash /setup-source.sh

echo "Running converter..."
docker run \
  -v $(pwd)/wd/types:/src:ro \
  -v $(pwd)/typedoc-converter.sh:/converter.sh:ro \
  -v $(pwd)/wd/types:/out \
  --rm \
  -it mcr.microsoft.com/dotnet/sdk:7.0 /bin/bash /converter.sh

cp -r $(pwd)/wd/types/LemmySharp/* ../LemmySharp
cp -r $(pwd)/wd/types/TypedocConverter/* ../TypedocConverter 