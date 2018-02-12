# Modified from https://github.com/fatedier/frp/blob/456ce09061bea765f511983b835faf6f6b44c91d/Dockerfile_multiple_build
FROM golang:1.8 as frp-build

RUN git clone --branch v0.16.0 --depth 1 https://github.com/fatedier/frp.git /go/src/github.com/fatedier/frp
ENV CGO_ENABLED=0
RUN cd /go/src/github.com/fatedier/frp && make frps

FROM alpine:3.7

COPY --from=frp-build /go/src/github.com/fatedier/frp/bin/frps /
COPY frps.ini /

EXPOSE 7001 7002
WORKDIR /
CMD ["/frps","-c","frps.ini"]
