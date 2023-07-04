#!/usr/bin/env bash
NUGET_API_KEY=$(cat ~/.nuget/lemmy.net.apikey)

dotnet pack
if [ $? -ne 0 ]; then
    echo "Failed to pack project, exiting."
    exit 1
fi

FILE=$(ls -Adrt1 Lemmy.Net/bin/Debug/* | tail -1)

dotnet nuget push $FILE -k $NUGET_API_KEY -s https://api.nuget.org/v3/index.json