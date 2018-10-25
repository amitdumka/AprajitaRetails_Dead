//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   version
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 1:30:29 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Version', [
            function () {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'version.js'
                    }
                };

                // External implementation
                return Class;
            }
        ]);
})();