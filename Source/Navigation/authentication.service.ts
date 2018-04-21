import { Injectable, isDevMode } from '@angular/core';
import { UserManager, WebStorageStateStore } from 'oidc-client';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class AuthenticationService {
    private _societies:any[];
    private _name:string;
    private _loggedIn:boolean;
    private _userManager:UserManager;

    // http://localhost:5000/be4c4da6-5ede-405f-a947-8aedad564b7f/CBS/connect/authorize?client_id=25c7ddac-dd1b-482a-8638-aaa909fd1f1c&redirect_uri=http%3A%2F%2Flocalhost%3A4200%2F&response_type=id_token&scope=openid%20email%20profile&state=c767449ef8d34ce7aa5a1335aa65f8d5&nonce=2fcacdb525c042d78e438e58c27085b5
    // http://localhost:4200/#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6ImY2YTdlYTY4ZmRiMzhkOTZmNjNkMmM4ZjA5MWJlYmQ3IiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MjM1MTc5MTgsImV4cCI6MTUyMzUxODIxOCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwL2JlNGM0ZGE2LTVlZGUtNDA1Zi1hOTQ3LThhZWRhZDU2NGI3Zi9jYnMiLCJhdWQiOiIyNWM3ZGRhYy1kZDFiLTQ4MmEtODYzOC1hYWE5MDlmZDFmMWMiLCJub25jZSI6Ijc3ZDA4MGY1N2ExZjRjNjk4ZGJiZGY0MjQ3OTc5MjNmIiwiaWF0IjoxNTIzNTE3OTE4LCJzaWQiOiJjYzM4OWVjMzRjYzQ4ZDllZmY4OTQyZDBkODExNWQ0ZCIsInN1YiI6Im9XNHVOQTZERUdfYllLVXFITWNUTkhUbno3UDBsTVdjbXFKYndxazZsb0EiLCJhdXRoX3RpbWUiOjE1MjM1MTc5MTMsImlkcCI6IjliMjk2OTc3LTc2NTctNGJjOC1iNWIwLTNmMGEyM2M0Mzk1OCIsIm5hbWUiOlsiRWluYXIgSW5nZWJyaWd0c2VuIiwiRWluYXIgSW5nZWJyaWd0c2VuIl0sImFtciI6WyJleHRlcm5hbCJdfQ.TR2SCZgi0kV9YYxJyMhoIacDv8T4OozsNDgF-JDHyN5VRUQWCZNl9WXKLpCejR44rxNWO-zY5idARTj96wvf_erE2NOeS4xmNqjgPcINb8rXPbENUbziIlf9u4JzRWk0wxYu3n9Vm2ntX2X18mrgPPqATZNkkKQsUKtElprItkVWblMjFUjKfCqwjr_0zrlCSn2eV4uxa1V5kz6G4bG2Y51_508O5dvJAMZartPPYnoFOm95ofZzWHHI9vjak8-M4HbhN1GohEHW9GifKzhc7fFzbZOOgBIuPWOLO6N0yg-n3Dw2v3RkNV6sbMVQJbz1uNxo_cst_eIbAJQnt7BHHw&scope=openid%20email%20profile&state=7b28db0d18b3426fad289fbab270315d&session_state=ZTV6bOmFDZ6mpPF8AMyr443WQ2DFdbf53ZTkX3Jt6Io.c5013f207eb75815167356274546341a
    // https://auth.humanitarian.id/?redirect=/oauth/authorize&client_id=cbs-staging&redirect_uri=http://localhost:5000/9b296977-7657-4bc8-b5b0-3f0a23c43958/signin-oidc&response_type=id_token&state=CfDJ8CeXhV5JBLFMkMDAcLC1jYI4TeEJgSQdAr2_aSlk6NLP34YYWLnDev1fKD8yRsU4-12IRB1C1qUxwrp2JBNR2wZqlRXZxN0VdSffgI-tCfIjfihJ9hLICrDKmUxmzBaXFHDWNDdO0B4SlnGLd5zdtHoKbEnVRMHr6Ak7n1E-Uij769tt55uZtE-Zn7gIWLAdqQHl__dJd7shba9bjGqrHISS-glA-dFWEgVG7pAdKhJETeGe3jI3V6T5U4VsII3Z75n7I5YxGBge4WfSRfQtir8TtIKwE3_k3sLR65Wg-HBKDyE6R-4o0ay_-70e7bjvT9CXUzBng7SA1QtEQvK_wk6vDm8n2lGgAC_bpkU-wMKyKM3dvmdIwg8FwsZK9u7HnFpGZoff0f6YCG93O_FtHz-CW4ykYlZ9m6prDlSwv0oTl_FDtv_EH9OvjSdIHWAeP1oqwTfSq5Naa-7iQvfnbOZlDKCDT12fUainQ9IGlQjzF7d1JoYuGXumV6B0u1DucKgjPDuAZPNKG4q2QtmPS_LJ08NbewbpKQkqQ5Qc5jLmy1dB-6YHPLcRoIUxqfeOcvJRxVlNU0jwcfqYov70XZDM7hQykXPUmzo1CaKuDPKJmgYvKu2t67xBbvh4KjFmqMSsFHBU6GYq9xfEHvLUasCsfjHfZ-eY4d0A676C-lvlNAGUOUZNF622MMMGM0o6MdwYo6NZrbW98D9S5mMehkS682KvXRg1ekQReom5dy8iqpESIxT8maPjcjnn-e1VoVLWxVYn3l1Pt-Z1W009dDbbdYJlYTg0M81_SxCophIqK-4do6e0LoViltinL96KnwsSiktaaQu4_hAvWbvWivJZVyGAbQHNWpd9BvKvzDrdzbwGi7JdOEmerolJivIig7mX7Ogt6lorb770j3Npbks&scope=openid&nonce=636591161218284720.NjA4MjkwNGMtYjBjYy00ZmE0LWE2NGEtNDQ5MTRjMmU4ZDg1YjQ5ZWUzODgtZWMwMS00MjkyLTk2YmQtNGIyZDIxMDEyNWJi#login
    // https://auth.humanitarian.id/?redirect=/oauth/authorize&client_id=cbs-staging&redirect_uri=https://dolittle.online/9b296977-7657-4bc8-b5b0-3f0a23c43958/signin-oidc&response_type=id_token&state=CfDJ8CeXhV5JBLFMkMDAcLC1jYI4TeEJgSQdAr2_aSlk6NLP34YYWLnDev1fKD8yRsU4-12IRB1C1qUxwrp2JBNR2wZqlRXZxN0VdSffgI-tCfIjfihJ9hLICrDKmUxmzBaXFHDWNDdO0B4SlnGLd5zdtHoKbEnVRMHr6Ak7n1E-Uij769tt55uZtE-Zn7gIWLAdqQHl__dJd7shba9bjGqrHISS-glA-dFWEgVG7pAdKhJETeGe3jI3V6T5U4VsII3Z75n7I5YxGBge4WfSRfQtir8TtIKwE3_k3sLR65Wg-HBKDyE6R-4o0ay_-70e7bjvT9CXUzBng7SA1QtEQvK_wk6vDm8n2lGgAC_bpkU-wMKyKM3dvmdIwg8FwsZK9u7HnFpGZoff0f6YCG93O_FtHz-CW4ykYlZ9m6prDlSwv0oTl_FDtv_EH9OvjSdIHWAeP1oqwTfSq5Naa-7iQvfnbOZlDKCDT12fUainQ9IGlQjzF7d1JoYuGXumV6B0u1DucKgjPDuAZPNKG4q2QtmPS_LJ08NbewbpKQkqQ5Qc5jLmy1dB-6YHPLcRoIUxqfeOcvJRxVlNU0jwcfqYov70XZDM7hQykXPUmzo1CaKuDPKJmgYvKu2t67xBbvh4KjFmqMSsFHBU6GYq9xfEHvLUasCsfjHfZ-eY4d0A676C-lvlNAGUOUZNF622MMMGM0o6MdwYo6NZrbW98D9S5mMehkS682KvXRg1ekQReom5dy8iqpESIxT8maPjcjnn-e1VoVLWxVYn3l1Pt-Z1W009dDbbdYJlYTg0M81_SxCophIqK-4do6e0LoViltinL96KnwsSiktaaQu4_hAvWbvWivJZVyGAbQHNWpd9BvKvzDrdzbwGi7JdOEmerolJivIig7mX7Ogt6lorb770j3Npbks&scope=openid&nonce=636591161218284720.NjA4MjkwNGMtYjBjYy00ZmE0LWE2NGEtNDQ5MTRjMmU4ZDg1YjQ5ZWUzODgtZWMwMS00MjkyLTk2YmQtNGIyZDIxMDEyNWJi#login

    constructor() {
        this._societies = ['Norway', 'Sweden'];
        this._loggedIn = false;

        this._userManager = new UserManager({
            authority: 'https://dolittle.online/be4c4da6-5ede-405f-a947-8aedad564b7f/CBS',
            //'http://localhost:5000/be4c4da6-5ede-405f-a947-8aedad564b7f/CBS',

            automaticSilentRenew: true,
            checkSessionInterval: 10000,
            client_id: '25c7ddac-dd1b-482a-8638-aaa909fd1f1c',
            filterProtocolClaims: true,
            loadUserInfo: true,
            post_logout_redirect_uri: '',
            redirect_uri: `${window.location.origin}/`,
            response_type: 'id_token',
            scope: 'openid email profile',
            silentRequestTimeout: 10000,
            silent_redirect_uri: '',
            userStore: new WebStorageStateStore({
                prefix: "cbs",
                store: window.localStorage
            })
        });
    }

    private populateUser(user:any, resolve: (loggedIn:boolean) => void) {
        if( Object.prototype.toString.call(user.profile.name) === '[object Array]' ) {
            this._name = user.profile.name[0];
        } else {
            this._name = user.profile.name;
        }
        this._loggedIn = true;
        resolve(true);
    }

    private update():Promise<boolean> {
        const self = this;
        let resolve;
        const promise = new Promise<boolean>((r) => { resolve = r; });
        if (isDevMode()) {
            this._name = 'DEV-MODE';
            this._loggedIn = true;
            resolve(true);
        } else {
            if( window.location.hash.indexOf('id_token=') >= 0 ) {
                this._userManager.signinRedirectCallback().then(function(user) {
                    self._userManager.storeUser(user);
                    window.location.hash = '';
                    self.populateUser(user, resolve);
                });
            } else {
                this._userManager.getUser().then(function(user) {
                    if( user ) {
                        self.populateUser(user, resolve);
                    } else {
                        self._userManager.signinRedirect({
                            state: { some:'state' }
                        }).then(function() {});
                    }
                });
            }
        }
        return promise;
    }

    get isLoggedIn():Observable<boolean> {
      return Observable.fromPromise(this.update());
    }

    get name():Observable<string> {
      return Observable.fromPromise(this.update().then(() => {
        return this._name;
      }));
    }

    get societies():Observable<any[]> {
      return Observable.fromPromise(this.update().then(() => {
        return this._societies;
      }));
    }
}
