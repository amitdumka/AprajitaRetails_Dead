//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   culture
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
        .factory('Culture', [
            function () {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'culture.js'
                    }
                };

                // Class cultures collection definition
                Class.Collection = ['pt-br', 'en-us'];

                // Class main culture definition
                Class.Default = 'pt-br';

                // External implementation
                return Class;
            }
        ]);
})();