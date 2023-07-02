#!/usr/bin/env bash
trap "exit" INT

echo "Installing TypedocConverter..."
dotnet tool install -g TypedocConverter
export PATH="$PATH:/root/.dotnet/tools"

apt update && apt install -y jq
jq 'del(.packageName, .readme, .symbolIdMap)' /src/output.json > types.json

TypedocConverter \
  --inputfile types.json \
  --splitfiles true \
  --outputdir /out \
  --namespace LemmySharp.Types \
  --nrt-disabled true \
  --array-type List \
  --any-type object \
  --json-mode system