FROM microsoft/dotnet:2.2-sdk-stretch

# Install Mono

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

# Install PowerShell

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get update \
  && apt-get install --yes --no-install-recommends \
    apt-utils \
    ca-certificates \
    curl \
    apt-transport-https \
    locales

RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -	
RUN curl https://packages.microsoft.com/config/debian/9/prod.list | tee /etc/apt/sources.list.d/microsoft.list

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get update \
  && apt-get install --yes --no-install-recommends \
    powershell

# Install Node

RUN curl -sL https://deb.nodesource.com/setup_8.x | bash -
RUN DEBIAN_FRONTEND=noninteractive \
  apt-get update \
  && apt-get install --yes --no-install-recommends \
    nodejs

# Clean

RUN DEBIAN_FRONTEND=noninteractive \
  apt-get clean \
  && rm -rf /var/lib/apt/lists/* \
  && rm -rf /tmp/* \
  && rm -rf /var/tmp/*
