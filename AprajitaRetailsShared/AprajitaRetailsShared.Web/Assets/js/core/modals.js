//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   modals
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 1:30:20 PM
//=========================================================================

(function () {
    'use strict';

    angular
        .module('shared')
        .factory('Modals', ['$timeout',
            function ($timeout) {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'modals.js'
                    }
                };

                // Actions definition
                Class.Enable = _Enable;
                Class.Disable = _Disable;
                Class.Hide = _Hide;
                Class.Show = _Show;

                // Events definition
                Class.GetDate = _GetDate;
                Class.SetDate = _SetDate;

                // Methods definition
                Class.Bind = _Bind;
                Class.Clean = _Clean;
                Class.Exists = _Exists;
                Class.IsShown = _IsShown;
                Class.Left = _Left;
                Class.Render = _Render;
                Class.Right = _Right;

                // Modals definition
                Class.Create = _Create;
                Class.Delete = _Delete;
                Class.Filters = _Filters;
                Class.Loading = _Loading;

                // Actions implementation
                function _Clean(modal) {
                    if (modal) {
                        $('#modal-' + modal + ' input:not([type="checkbox"])').val(null);
                        $('#modal-' + modal + ' input[type="checkbox"]').prop('checked', null);
                        $('#modal-' + modal + ' [pg-datepicker]').each(function () {
                            $(this).datepicker('setDate', null);
                        });
                        $('#modal-' + modal + ' .input-daterange input').each(function () {
                            $(this).datepicker('setDate', null);
                        });

                        if ($('#modal-' + modal + ' form input:not([pg-datepicker]):not([type="checkbox"]):first').length > 0) {
                            $timeout(function () {
                                $('#modal-' + modal + ' form input:not([pg-datepicker]):not([type="checkbox"]):first').focus();
                            }, 400);
                        }
                    }
                    else {
                        $('#modal-create input:not([type="checkbox"])').val(null);
                        $('#modal-create input[type="checkbox"]').prop('checked', null);
                        $('#modal-create [pg-datepicker]').each(function () {
                            $(this).datepicker('setDate', null);
                        });
                        $('#modal-create .input-daterange input').each(function () {
                            $(this).datepicker('setDate', null);
                        });

                        if ($('#modal-create form input:not([pg-datepicker]):not([type="checkbox"]):first').length > 0) {
                            $timeout(function () {
                                $('#modal-create form input:not([pg-datepicker]):not([type="checkbox"]):first').focus();
                            }, 400);
                        }
                    }

                    if ($('.cs-wrapper')) {
                        $timeout(function () {
                            $('.cs-wrapper').each(function () {
                                var select = $('select', this);
                                $(this).replaceWith(select);
                            });

                            $('select.cs-select').each(function () {
                                $(this).wrap('<div class="cs-wrapper" />');
                                new SelectFx(this);
                            });
                        }, 100);
                    }
                    else {
                        $timeout(function () {
                            $('select.cs-select').each(function () {
                                $(this).wrap('<div class="cs-wrapper" />');
                                new SelectFx(this);
                            });
                        }, 100);
                    }
                }

                function _Disable(id) {
                    if (id) {
                        $('#' + id).parent('.form-group').addClass('disabled');
                        $('#' + id).parents('.form-group').addClass('disabled');
                        $('#' + id).prop('disabled', 'disabled');
                        $('#' + id).addClass('disabled');
                    }
                    else {
                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox, '
                            + 'form .cs-wrapper').parent('.form-group').addClass('disabled');

                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox').prop('disabled', 'disabled');

                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox').addClass('disabled');

                        $('form .actions').hide();
                    }
                }

                function _Enable(id) {
                    if (id) {
                        $('#' + id).parent('.form-group').removeClass('disabled');
                        $('#' + id).parents('.form-group').removeClass('disabled');
                        $('#' + id).removeClass('disabled');
                        $('#' + id).prop('disabled', '');
                    }
                    else {
                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox, '
                            + 'form .cs-wrapper').parent('.form-group').removeClass('disabled');

                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox').removeClass('disabled');

                        $('form input, '
                            + 'form textarea, '
                            + 'form select, '
                            + 'form .checkbox').prop('disabled', '');

                        $('form .actions').show();
                    }
                }

                function _Hide(name) {
                    $('#modal-loading-title').text('Carregando...');
                    $('#modal-' + name).modal('hide');
                }

                function _Show(name, title, callback) {
                    if (name !== 'loading') {
                        if ($('.cs-wrapper')) {
                            $timeout(function () {
                                $('.cs-wrapper').each(function () {
                                    var select = $('select', this);
                                    $(this).replaceWith(select);
                                });

                                $('select.cs-select').each(function () {
                                    $(this).wrap('<div class="cs-wrapper" />');
                                    new SelectFx(this);
                                });
                            }, 100);
                        }
                        else {
                            $timeout(function () {
                                $('select.cs-select').each(function () {
                                    $(this).wrap('<div class="cs-wrapper" />');
                                    new SelectFx(this);
                                });
                            }, 100);
                        }
                    }

                    if (!_IsShown(name)) {
                        if (name === 'loading') {
                            var _title = title && title !== 'default' ? title : 'Carregando...';
                            $('#modal-' + name + '-title').text(_title);
                        }

                        $('#modal-' + name).modal({
                            show: true,
                            keyboard: name === 'filters',
                            backdrop: 'static'
                        });

                        if (name === 'create') {
                            $timeout(function () {
                                if ($('form[disabled]').length > 0) {
                                    _Disable();
                                    _Render();
                                }
                                else {
                                    _Enable();
                                    _Render();
                                }
                            }, 100);
                        }

                        if ($('#modal-' + name + ' form input:not([pg-datepicker]):not([pg-daterangepicker]):not([type="checkbox"]):first').length > 0) {
                            $timeout(function () {
                                $('#modal-' + name + ' form input:not([pg-datepicker]):not([pg-daterangepicker]):not([type="checkbox"]):first').focus();
                            }, 400);
                        }
                    }

                    if (callback && typeof callback === 'function') {
                        callback();
                    }
                }

                // Events implementation
                function _Events() {
                    $('div.cs-select.cs-skin-slide').on({
                        mouseover: function () {
                            $(this).parents('.form-group-default').css('border', '1px solid rgb(204, 204, 204)');
                        },
                        mouseleave: function () {
                            $(this).parents('.form-group-default').css('border', '1px solid rgba(0, 0, 0, 0.07)');
                        },
                        focus: function () {
                            $(this).parents('.form-group-default').css('border', '1px solid rgb(204, 204, 204)');
                        },
                        blur: function () {
                            $(this).parents('.form-group-default').css('border', '1px solid rgba(0, 0, 0, 0.07)');
                        }
                    });
                }

                function _GetDate(id, value) {
                    if ($('#' + id)) {
                        if ($('#' + id).val()) {
                            return new Date(moment(value, 'DD-MM-YYYY').format('YYYY-MM-DD')).toUTC();
                        }
                    }

                    return null;
                }

                function _SetDate(id, value) {
                    if ($('#' + id)) {
                        if ($('#' + id).val()) {
                            $('#' + id).datepicker('setDate', value);
                        }
                    }
                }

                // Methods implementation
                function _Bind(modal, event, callback) {
                    $('#modal-' + modal).on(event, function () {
                        callback();
                    });
                }

                function _Exists(name) {
                    return $('#modal-' + name) !== undefined && $('#modal-' + name) !== null;
                }

                function _IsShown(name) {
                    return ($('#modal-' + name).data('bs.modal') || {}).isShown;
                }

                function _Left(name) {
                    if (!$('#modal-' + name).hasClass('open')) {
                        $('#modal-' + name).addClass('open');
                    }
                }

                function _Right(name) {
                    if ($('#modal-' + name).hasClass('open')) {
                        $('#modal-' + name).removeClass('open');
                    }
                }

                function _Render(id) {
                    var elem = $('#' + id);
                    if (elem && elem.length > 0) {
                        elem = elem[0];
                        if (elem) {
                            if ($(elem).parents('.cs-wrapper')) {
                                $timeout(function () {
                                    var parents = $(elem).parents('.cs-wrapper');
                                    var select = $(parents).find('select').context;

                                    $(parents).replaceWith(select);
                                    $(select).wrap('<div class="cs-wrapper" />');
                                    new SelectFx(select);

                                    _Events();
                                }, 100);
                            }
                            else {
                                $timeout(function () {
                                    $(elem).wrap('<div class="cs-wrapper" />');
                                    new SelectFx(elem);

                                    _Events();
                                }, 100);
                            }
                        }
                    }
                    else if ($('.cs-wrapper')) {
                        $timeout(function () {
                            $('.cs-wrapper').each(function () {
                                var select = $('select', this);
                                $(this).replaceWith(select);
                            });

                            $('select.cs-select').each(function () {
                                $(this).wrap('<div class="cs-wrapper" />');
                                new SelectFx(this);
                            });

                            _Events();
                        }, 100);
                    }
                    else {
                        $timeout(function () {
                            $('select.cs-select').each(function () {
                                $(this).wrap('<div class="cs-wrapper" />');
                                new SelectFx(this);
                            });

                            _Events();
                        }, 100);
                    }
                }

                // Modals implementation
                function _Create(title, callback) {
                    _Show('create', title, callback);
                }

                function _Delete(title, callback) {
                    _Show('delete', title, callback);
                }

                function _Filters(title, callback) {
                    _Show('filters', title, callback);
                }

                function _Loading(title, callback) {
                    _Show('loading', title, callback);
                }

                // External implementation
                return Class;
            }
        ]);
})();