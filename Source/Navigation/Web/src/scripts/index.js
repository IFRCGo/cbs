(function() {
    var Oidc = require('oidc-client');
    var ko = require('knockout');

    var index = function() {
        var self = this;

        this.nationalSocieties = ko.observableArray([
            'Norway',
            'Sweden'
        ]);
        this.currentNationalSociety = ko.observable();
        this.name = ko.observable('blah');
        this.loggedIn = ko.observable(false);
        
        // http://localhost:9999/#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjNjNGFkZWRmZjdkYmRlYTRkYjBjZGRmNjViMmZiNWViIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MjI4MzE2MDksImV4cCI6MTUyMjgzMTkwOSwiaXNzIjoiaHR0cDovL2RvbGl0dGxlLm9ubGluZS9iZTRjNGRhNi01ZWRlLTQwNWYtYTk0Ny04YWVkYWQ1NjRiN2YvY2JzIiwiYXVkIjoiMjVjN2RkYWMtZGQxYi00ODJhLTg2MzgtYWFhOTA5ZmQxZjFjIiwibm9uY2UiOiJjOTZkMTM4NDBmMDI0NzVhODE4Yzc5YjNiYzc3MzkxNiIsImlhdCI6MTUyMjgzMTYwOSwic2lkIjoiYTZkMzNlYTg3YTUxNGI2ZjY5NTRhOWUxYTQ5MWJmZDciLCJzdWIiOiJvVzR1TkE2REVHX2JZS1VxSE1jVE5IVG56N1AwbE1XY21xSmJ3cWs2bG9BIiwiYXV0aF90aW1lIjoxNTIyODMxNTQ4LCJpZHAiOiI5YjI5Njk3Ny03NjU3LTRiYzgtYjViMC0zZjBhMjNjNDM5NTgiLCJuYW1lIjpbIkVpbmFyIEluZ2VicmlndHNlbiIsIkVpbmFyIEluZ2VicmlndHNlbiJdLCJhbXIiOlsiZXh0ZXJuYWwiXX0.nd4kIR_VlPe42kj1uOlbBEV38b_qHUtlmkdP0t5sP8vQj87DOdjyEFx-4ukXgMNzZFD5NGHK6KpgsMKSjcstGzcGIEf-Ktxgbv7rTnd_JRwCQZJY8OS9RG8VhplBoCzw4NPWnkq0xIzkPs48_cEpMJzCahR8jdwrOS5gqtdVB3xtnRJWtmjeaWgPZlsCADum3yWQAf8hmaFhQftmV-aN0npAy-1XZYFFAfxLI9xk6a4Iv96UrFSnHi4xddRkgMFTbFqEPAqgZQ0yFZDLORGx6I1pakSMLMaUYwVLYF26fNf2p0odby-_bVY8NjhGglzpf7KXqpju4HkLpEz-Dkq7-g&scope=openid%20email%20profile&state=928a0e7f01b94e77ab6eae59320e2320&session_state=aw_1A7T8rRiZoZFw7_9U1HW0Hb5TaCZLMUxHDoL1ARQ.ecb56c1224799f3726b4b9e8de85044b

        var userManager = new Oidc.UserManager({
            accessTokenExpiringNotificationTime: 1,
            authority: `https://dolittle.online/be4c4da6-5ede-405f-a947-8aedad564b7f/CBS`,
            automaticSilentRenew: true,
            checkSessionInternal: 10000,
            client_id: '25c7ddac-dd1b-482a-8638-aaa909fd1f1c',
            filterProtocolClaims: true,
            loadUserInfo: true,
            post_logout_redirect_uri: '',
            redirect_uri: `${window.location.origin}/`,
            response_type: 'id_token',
            scope: 'openid email profile',
            silentRequestTimeout: 10000,
            silent_redirect_uri: '',
            userStore: new Oidc.WebStorageStateStore({
                prefix: "cbs",
                store: window.localStorage
            })
        });

        if( window.location.hash.indexOf('id_token=') >= 0 ) {
            userManager.signinRedirectCallback().then(function(user) {
                userManager.storeUser(user);
                window.location.hash = '';
            });
            
        }

        userManager.getUser().then(function(user) {
            if( user ) {
                if( Object.prototype.toString.call(user.profile.name) === '[object Array]' )
                {
                    self.name(user.profile.name[0]);
                } else 
                {
                    self.name(user.profile.name);
                }
                self.loggedIn(true);
            }
        });

        this.login = function() {
            userManager.signinRedirect({
                state: {}
            }).then(function(request) {
                window.location = request.url;
            });
        }
    };

    ko.applyBindings(new index());
})();
