#!/usr/bin/env bash
set -euo pipefail

readonly repository_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
readonly upstream_commit="48bd89285e8c3da85cddb020ce8dbc3c94846670"
readonly archive_url="https://github.com/LemmyNet/lemmy-js-client/archive/${upstream_commit}.tar.gz"
readonly temporary_directory="$(mktemp -d)"
trap 'rm -rf "${temporary_directory}"' EXIT

curl --fail --location --silent --show-error "${archive_url}" \
  | tar --extract --gzip --directory "${temporary_directory}"

node "${repository_root}/utils/generate-models.mjs" \
  "${temporary_directory}/lemmy-js-client-${upstream_commit}/src/types"
