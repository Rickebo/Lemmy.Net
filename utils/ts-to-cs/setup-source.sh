#!/usr/bin/env bash
trap "exit" INT

#apt update && curl https://sh.rustup.rs -sSf | sh -s -- -y

REPOS=(lemmy-js-client)
REPO_BASE=/wd

echo "Running as uid: $UID and gid: $GID"

cd /wd

for REPO in ${REPOS[@]}; do
  ORIGIN="https://github.com/LemmyNet/$REPO.git"
  
  if [ ! -d $REPO ]; then
    echo "Repo does not exist, cloning from $ORIGIN..."
    git clone --recurse-submodules $ORIGIN
  else
    echo "Pulling repo..."
    git -C $REPO pull 
  fi
done

cd lemmy-js-client
npm install -g --save-dev typedoc
rm -f /out/output.json
typedoc src/index.ts --json /out/output.json 