//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   interceptor
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 3:05:38 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Interceptor', [
            function () {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'interceptor.js'
                    }
                };

                // Methods definition
                Class.Request = _Request;

                // Methods implementation
                function _Request(config) {
                    config.headers['user'] = window.localStorage.getItem('username');
                    return config;
                }

                // External implementation
                return Class;
            }
        ]);
})();