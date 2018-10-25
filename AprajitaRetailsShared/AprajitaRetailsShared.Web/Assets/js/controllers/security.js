//=========================================================================
// Project  :   Shared.Web.Layout.Security.Assets.js.controllers
// Model    :   security
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 1:08:59 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('guard')
        .controller('securityCtrl', ['Core', 'Alerts', 'Exceptions', 'Layouts', 'Modals',
            function (Core, Alerts, Exceptions, Layouts, Modals) {
                var Class = this;

                // Class main objects definition
                Class.Object = {};

                // Class logging definition
                Class.Logging = {
                    Enabled: true,
                    Location: 'security.js'
                };

                // Actions definition
                Class.ShowVersion = _ShowVersion;

                // Methods definition
                Class.Authenticate = _Authenticate;

                // Layout definition
                Class.Layout = Layouts.Get('security');

                // Start definition
                _Start();

                // Start implementation
                function _Start() {
                    Core.Configure('security as Acesso ao Sistema', Class);
                }

                // Actions implementation
                function _ShowVersion() {
                    Modals.Create();
                }

                // Methods implementation
                function _Authenticate() {
                    if (Class.Object) {
                        Core.SignIn(Class, AfterSignIn);
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Main.Forms.EmptyFields);
                    }
                }

                // Callbacks implementation
                function AfterSignIn(result) {
                    if (data.token && data.token.access_token) {
                        Core.Storage('token', data.token.access_token);

                        if (vm.User.Login) {
                            Core.Storage('username', vm.User.Login);
                        }

                        window.location = 'index.html#app/home';
                    }
                    else {
                        Alerts.Error(Exceptions.Shared.Controllers.Security.BadUsernameOrPassword);
                    }
                }
            }
        ]);
})();