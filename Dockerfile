FROM microsoft/dotnet:latest

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get update \
  && apt-get install --yes \
  curl \
  gnupg \
  && apt-key adv \
  --keyserver hkp://keyserver.ubuntu.com:80 \
  --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF

RUN echo "deb http://download.mono-project.com/repo/debian stretch main" \
  | tee /etc/apt/sources.list.d/mono-official.list

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get update \
  && apt-get install --yes \
  mono-devel

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get clean \
  && rm -rf /var/lib/apt/lists/* \
  && rm -rf /tmp/* \
  && rm -rf /var/tmp/*