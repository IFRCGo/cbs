#!/usr/bin/env bash

set -x

export DEBIAN_FRONTEND=noninteractive
export WORKSPACE_DIR=/workspace
export BUILD_DIR=${WORKSPACE_DIR}/Build

if [ "$PWD" != "$WORKSPACE_DIR" ]; then
  # Control will enter here if $DIRECTORY doesn't exists.
  echo "Go to /workspace directory before running this script."
  exit 1
fi

cd $BUILD_DIR
# curl -Lsfo build.sh \
#   https://cakebuild.net/download/bootstrapper/linux \
#   && chmod +x build.sh \
#   && ${PWD}/build.sh
${PWD}/build.sh