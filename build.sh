#!/usr/bin/env bash

set -x

export DEBIAN_FRONTEND=noninteractive
export WORKSPACE_DIR=/workspace
export BUILD_DIR=${WORKSPACE_DIR}/Build

if [ "$PWD" != "$WORKSPACE_DIR" ]; then
  echo "Build helper script to be run inside a container."
  echo "Go to $WORKSPACE_DIR directory before running this script."
  exit 1
fi

cd $BUILD_DIR \
  && ${PWD}/build.sh