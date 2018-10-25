//=========================================================================
// Project  :   Shared.Web.JavaScript.Controllers.core
// Model    :   errors
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 2:59:39 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .controller('errorsCtrl', ['$state', '$stateParams', 'Core', 'Layouts', 'Modals',
            function ($state, $stateParams, Core, Layouts, Modals) {
                var Class = this;

                // Class parameters definition
                Class.Received = null;

                // Class authority definition
                Class.Permissions = null;
                Class.User = null;

                // Class logging definition
                Class.Logging = {
                    Enabled: true,
                    Location: 'errors.js'
                };

                // Layout definition
                Class.Layout = Layouts.Get('errors');

                // Start definition
                _Start();

                // Start implementation
                function _Start() {
                    Modals.Loading();
                    Core.Configure('errors as Oops!', Class);
                    Core.GetLoggedUser(function (User) {
                        if ($stateParams.message) {
                            Class.Received = $stateParams.message;
                        }
                        else {
                            $state.go('shared.home');
                        }

                        Class.Permissions = User.Permissions;
                        Class.User = User;
                    });
                }
            }]);
})();