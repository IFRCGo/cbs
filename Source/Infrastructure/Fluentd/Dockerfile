# Based on Dockerfiles found here: https://github.com/fluent/fluentd-kubernetes-daemonset
# Using plugin : https://github.com/fluent/fluent-plugin-kafka

FROM fluent/fluentd:v0.12.33-debian
USER root
WORKDIR /home/fluent
ENV PATH /home/fluent/.gem/ruby/2.3.0/bin:$PATH

RUN buildDeps="sudo make gcc g++ libc-dev ruby-dev libffi-dev patch" \
     && apt-get update \
     && apt-get install \
     -y --no-install-recommends \
     $buildDeps \
    && echo 'gem: --no-document' >> /etc/gemrc \
    && gem install fluent-plugin-secure-forward \
    && gem install fluent-plugin-record-reformer \
    # && gem install fluent-plugin-logentries \
    && gem install fluent-plugin-kubernetes_metadata_filter \
    && gem install ffi \
    && gem install fluent-plugin-systemd -v 0.0.8 \
    && gem install fluent-plugin-elasticsearch \
    && SUDO_FORCE_REMOVE=yes \
    apt-get purge -y --auto-remove \
                  -o APT::AutoRemove::RecommendsImportant=false \
                  $buildDeps \
 && rm -rf /var/lib/apt/lists/* \
    && gem sources --clear-all \
    && rm -rf /tmp/* /var/tmp/* /usr/lib/ruby/gems/*/cache/*.gem

# Copy configuration files
COPY ./Config/* /fluentd/etc/

# Copy plugins
COPY ./Plugins /fluentd/plugins/

# Environment variables
ENV FLUENTD_OPT=""
ENV FLUENTD_CONF="fluent.conf"

# jemalloc is memory optimization only available for td-agent
# td-agent is provided and QA'ed by treasuredata as rpm/deb/.. package
# -> td-agent (stable) vs fluentd (edge)
#ENV LD_PRELOAD="/usr/lib/libjemalloc.so.2"

# Run Fluentd
CMD exec fluentd -c /fluentd/etc/$FLUENTD_CONF -p /fluentd/plugins $FLUENTD_OPT