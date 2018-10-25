//=========================================================================
// Project  :   Shared.Web.Layout.Core.Assets.js.core
// Model    :   tables
//=========================================================================
// Author   :   Leno Carvalho
// Location :   VOSTRO
//=========================================================================
// Created  :   4/11/2017 6:03:47 PM
//=========================================================================

(function() {
    'use strict';

    angular
        .module('shared')
        .factory('Tables', [
            function() {
                // Class definition
                var Class = {
                    Logging: {
                        Enabled: true,
                        Location: 'tables.js'
                    }
                };

                // Methods definition
                Class.Create = _Create;

                // Start implementation
                function _Create() {
                    var buttons = {
                        'copy': {
                            extend: 'copyHtml5',
                            text: '<i class="fa fa-files-o"></i>',
                            titleAttr: 'Copiar',
                            title: _App.Name
                        },
                        'excel': {
                            extend: 'excelHtml5',
                            text: '<i class="fa fa-file-excel-o"></i>',
                            titleAttr: 'Excel',
                            filename: _App.Name,
                            title: _App.Name,
                            customize: function(xlsx) {
                                var sheet = xlsx.xl.worksheets['sheet1.xml'];
                                var numrows = 4;
                                var clR = $('row', sheet);

                                clR.each(function() {
                                    var attr = $(this).attr('r');
                                    var ind = parseInt(attr);
                                    ind = ind + numrows;
                                    $(this).attr("r", ind);
                                });

                                $('row c ', sheet).each(function() {
                                    var attr = $(this).attr('r');
                                    var pre = attr.substring(0, 1);
                                    var ind = parseInt(attr.substring(1, attr.length));
                                    ind = ind + numrows;
                                    $(this).attr("r", pre + ind);
                                });

                                function Addrow(index, data) {
                                    var msg = '<row r="' + index + '">'
                                    for (i = 0; i < data.length; i++) {
                                        var key = data[i].key;
                                        var value = data[i].value;
                                        msg += '<c t="inlineStr" r="' + key + index + '">';
                                        msg += '<is>';
                                        msg += '<t>' + value + '</t>';
                                        msg += '</is>';
                                        msg += '</c>';
                                    }
                                    msg += '</row>';
                                    return msg;
                                }

                                var name = Addrow(1, [{ key: 'A', value: 'SIP' }, { key: 'B', value: _App.Title }]);
                                var user = Addrow(2, [{ key: 'A', value: 'Usuario' }, { key: 'B', value: localStorage.getItem('username') }]);
                                var date = Addrow(3, [{ key: 'A', value: 'Data' }, { key: 'B', value: _GetCurrentDatetime() }]);
                                var none = Addrow(4, [{ key: 'A', value: '' }, { key: 'B', value: '' }]);

                                sheet.childNodes[0].childNodes[1].innerHTML = name + user + date + none + sheet.childNodes[0].childNodes[1].innerHTML;
                            }
                        },
                        'csv': {
                            extend: 'csvHtml5',
                            text: '<i class="fa fa-file-text-o"></i>',
                            titleAttr: 'Csv',
                            filename: _App.Name,
                            title: _App.Name,
                            customize: function(csv) {
                                return 'SIP,' + _App.Title + '\n' + 'Usuário: ,' + localStorage.getItem('username') + '\n' + 'Data: ,' + _GetCurrentDatetime() + '\n\n' + csv;
                            }
                        },
                        'pdf': {
                            extend: 'pdfHtml5',
                            text: '<i class="fa fa-file-pdf-o"></i>',
                            titleAttr: 'Pdf',
                            filename: _App.Name,
                            title: _App.Name,
                            message: 'Usuário: \t' + localStorage.getItem('username') + '\n' + 'Data: \t' + _GetCurrentDatetime() + '\n\n'
                        },
                        'print': {
                            extend: 'print',
                            text: '<i class="fa fa-print"></i>',
                            titleAttr: 'Imprimir',
                            filename: _App.Name,
                            title: '<h1 class="font-montserrat fs-20">' + _App.Name + '</h1>'
                            + '<div class="font-montserrat upper fs-11">'
                            + '<span class="bold m-b-0">Usuário: <span class="hint-text">' + localStorage.getItem('username') + '</span></span><br>'
                            + '<span class="bold m-b-30">Data: <span class="hint-text">' + _GetCurrentDatetime() + '</span></span><br>'
                            + '</div>'
                        }
                    };

                    if (options === null
                        || typeof options !== 'object') {
                        options.buttons.push(buttons['copy']);
                        options.buttons.push(buttons['excel']);
                        options.buttons.push(buttons['csv']);
                        options.buttons.push(buttons['pdf']);
                        options.buttons.push(buttons['print']);

                        options = {
                            columns: [{ title: "Sem dados" }],
                            data: [],
                            limit: 25,
                            order: [[0, 'asc']],
                            table: 'table',
                            title: 'SIP - Slots',
                            fixedColumns: false,
                            paging: true,
                            info: true,
                            searching: true,
                            scrollY: 280,
                            scrollX: true,
                            scrollCollapse: true,
                            buttons: options.buttons
                        };
                    }
                    else if (options !== null
                        && typeof options === 'object') {
                        var optLimit = typeof options.limit === 'number' ?
                            options.limit : 25;

                        var optFixedColumns = typeof options.fixedColumns === 'object' ?
                            options.fixedColumns : false;

                        var optPaging = typeof options.paging === 'boolean' ?
                            options.paging : true;

                        var optInfo = typeof options.info === 'boolean' ?
                            options.info : true;

                        var optSearching = typeof options.searching === 'boolean' ?
                            options.searching : true;

                        var optScrollY = typeof options.scrollY === 'boolean' ?
                            options.scrollY : typeof options.scrollY === 'number' ?
                                options.scrollY : 280;

                        var optScrollX = typeof options.scrollX === 'boolean' ?
                            options.scrollX : true;

                        var optScrollCollapse = typeof options.scrollCollapse === 'boolean' ?
                            options.scrollCollapse : true;

                        if (options.buttons !== undefined) {
                            var buttonsArray = options.buttons;

                            options.buttons = [];
                            for (var i = 0; i < buttonsArray.length; i++) {
                                options.buttons.push(buttons[buttonsArray[i]]);
                            }
                        }
                        else {
                            options.buttons = [];

                            options.buttons.push(buttons['copy']);
                            options.buttons.push(buttons['excel']);
                            options.buttons.push(buttons['csv']);
                            options.buttons.push(buttons['pdf']);
                            options.buttons.push(buttons['print']);
                        }

                        options = {
                            columns: options.columns || [{ title: "Sem dados" }],
                            data: options.data || [],
                            order: options.order || [[0, 'asc']],
                            table: options.table || 'table',
                            title: options.title || 'SIP - Slots',
                            limit: optLimit,
                            fixedColumns: optFixedColumns,
                            paging: optPaging,
                            info: optInfo,
                            searching: optSearching,
                            scrollY: optScrollY,
                            scrollX: optScrollX,
                            scrollCollapse: optScrollCollapse,
                            buttons: options.buttons
                        };
                    }
                    else {
                        console.log('O objeto de configurações do componente de tabelas não foi encontrado ou não é válido para esta operação!');
                        return;
                    }

                    if ($('#' + options.table).length <= 0) {
                        return;
                    }

                    $('#navbar-clean').on('click', function() {
                        if ($('#' + options.table + ' tbody tr.selected')) {
                            $('#' + options.table + ' tbody tr.selected').removeClass('selected');
                        }

                        if ($('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]:checked')) {
                            $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]:checked').prop('checked', false);
                        }

                        if (options.fixedColumns) {
                            if ($('.DTFC_Cloned tbody tr.selected')) {
                                $('.DTFC_Cloned tbody tr.selected').removeClass('selected');
                            }

                            if ($('.DTFC_Cloned tbody tr td .checkbox input[type="checkbox"]:checked')) {
                                $('.DTFC_Cloned tbody tr td .checkbox input[type="checkbox"]:checked').prop('checked', false);
                            }
                        }

                        _HideMultiple();
                        _HideActions();
                    });

                    $.extend($.fn.dataTableExt.oSort, {
                        "date-dmy-pre": function(a) {
                            var date = a.split('/');
                            return (date[2] + date[1] + date[0]) * 1;
                        },

                        "date-dmy-asc": function(a, b) {
                            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
                        },

                        "date-dmy-desc": function(a, b) {
                            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
                        }
                    });

                    $('#' + options.table).DataTable({
                        data: options.data,
                        order: options.order,
                        columns: options.columns,
                        dom: "<'row'<'col-sm-12 col-md-6 col-lg-6'B><'col-sm-12 col-md-6 col-lg-6'f>>" +
                        "<'row'<'col-sm-12'tr>>" +
                        "<'row'<'col-sm-6'i><'col-sm-6'p>>",
                        searching: options.searching,
                        destroy: true,
                        width: '100%',
                        autoWidth: false,
                        pageLength: options.limit,
                        lengthChange: false,
                        fixedColumns: options.fixedColumns,
                        paging: options.paging,
                        info: options.info,
                        scrollY: options.scrollY,
                        scrollX: options.scrollX,
                        scrollCollapse: options.scrollCollapse,
                        buttons: options.buttons,
                        language: {
                            "emptyTable": "Não há dados disponíveis",
                            "zeroRecords": "Não há dados disponíveis",
                            "info": "Exibindo página <b>_PAGE_</b> de <b>_PAGES_</b> - _MAX_ resultado(s)",
                            "infoEmpty": "Não há dados disponíveis",
                            "infoFiltered": "(filtrado de <b>_MAX_</b> itens no total)",
                            "sSearch": "Pesquisar: ",
                            "lengthMenu": "_MENU_ Resultados",
                            "oPaginate": {
                                "sFirst": "Primeira",
                                "sPrevious": "Anterior",
                                "sNext": "Próxima",
                                "sLast": "Última"
                            },
                            buttons: {
                                copyTitle: 'Copiar Registros',
                                copySuccess: {
                                    _: 'Copiados %d registros',
                                    1: 'Copiado 1 registro'
                                }
                            }
                        },
                        fnDrawCallback: function(oSettings) {
                            $('[data-toggle="tooltip"]').tooltip();

                            $('#' + options.table + ' tbody tr').unbind('click');
                            $('#' + options.table + ' tbody tr').off('click');
                            $('#' + options.table + ' tbody tr td span.flight').unbind('click');
                            $('#' + options.table + ' tbody tr td span.flight').off('click');
                            $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').unbind('click');
                            $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').off('click');

                            if ($('#' + options.table).data('selection') === false) {
                                return;
                            }

                            $('#navbar-selectall').on('click', function() {
                                $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').parents('tr').addClass('selected');
                                $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').prop('checked', true);

                                if ($('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').length <= 0) {
                                    _HideMultiple();
                                    _HideActions();
                                }
                                else if ($('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').length === 1) {
                                    _ShowActions();
                                    _HideMultiple();
                                    _ShowDeleteMarked();
                                }
                                else {
                                    _ShowMultiple();
                                    _HideMarkAll();
                                }
                            });

                            $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').on('click', function() {
                                if (options.fixedColumns) {
                                    var id = $(this).attr('id');

                                    $('#' + id, '.DTFC_Cloned').parents('tr').toggleClass('selected');
                                    $('#' + id, '.DTFC_Cloned').prop('checked', $(this).prop('checked'));
                                }

                                var count = $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]:checked').length;
                                var length = $('#' + options.table + ' tbody tr td .checkbox input[type="checkbox"]').length;

                                if ($(this).parents('tr').hasClass('selected')) {
                                    $(this).parents('tr').removeClass('selected');
                                }
                                else {
                                    $(this).parents('tr').addClass('selected');
                                }

                                if (count === 1 && length === 1) {
                                    _ShowActions();
                                    _HideMultiple();
                                    _ShowDeleteMarked();
                                }
                                else if (count === 1 && length > 1) {
                                    _ShowActions();
                                    _HideMultiple();
                                    _ShowMarkAll();
                                    _ShowDeleteMarked();
                                }
                                else if (count === length) {
                                    _ShowMultiple();
                                    _HideMarkAll();
                                }
                                else if (count > 1) {
                                    _ShowMultiple();
                                }
                                else if (count <= 0) {
                                    _HideMultiple();
                                    _HideActions();
                                }
                            });
                        }
                    });

                    if (typeof callback === 'function') {
                        callback();
                    }
                }

                // External implementation
                return Class;
            }
        ]);
})();