//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   navbar
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
        .factory('Navbar', [
            function () {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'navbar.js'
                    }
                };

                // External implementation
                return Class;
            }
        ]);
})();