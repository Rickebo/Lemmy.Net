FROM node:bullseye

RUN apt update \
  && mkdir -p /usr/share/man/man1 \
  && apt install -y \
    git mercurial xvfb apt \
    locales sudo openssh-client ca-certificates tar gzip parallel \
    net-tools netcat unzip zip bzip2 gnupg curl wget make man

RUN locale-gen C.UTF-8 || true
ENV LANG=C.UTF-8

RUN RUSTUP_URL="https://sh.rustup.rs" \
  && curl --silent --show-error --location --fail --retry 3 --proto '=https' --tlsv1.2 --output /tmp/rustup-linux-install.sh $RUSTUP_URL \
  && bash /tmp/rustup-linux-install.sh -y

RUN /root/.cargo/bin/rustup target add x86_64-pc-windows-msvc
ENV PATH /root/.npm/bin:/root/.cargo/bin:${PATH}