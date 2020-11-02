/* ------------------------------------------------------------------------------
 *
 *  # Custom JS code
 *
 *  Place here all your custom js. Make sure it's loaded after app.js
 *
 * ---------------------------------------------------------------------------- */


/* ------------------------------------------------------------------------------
 *
 *  # CKEditor editor
 *
 *  Demo JS code for editor_ckeditor.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------
if ($("#Description").length!=0) {
    var CKEditor = function () {


        //
        // Setup module components
        //

        // CKEditor
        var _componentCKEditor = function () {
            if (typeof CKEDITOR == 'undefined') {
                console.warn('Warning - ckeditor.js is not loaded.');
                return;
            }

  
            // Setup
            CKEDITOR.replace('Description', {
                height: 300,
                extraPlugins: 'forms'
            });
        };


        return {
            init: function () {
                _componentCKEditor();
            }
        }
    }();


    // Initialize module
    // ------------------------------

    document.addEventListener('DOMContentLoaded', function () {
        CKEditor.init();
    });

}
if ($(".category-datatable").length!=0) {
    var DatatableBasic = function () {
        // Basic Datatable examples
        var _componentDatatableBasic = function () {
            if (!$().DataTable) {
                console.warn('Warning - datatables.min.js is not loaded.');
                return;
            }

            // Setting datatable defaults
            $.extend($.fn.dataTable.defaults, {
                autoWidth: false,
                columnDefs: [{
                    orderable: false,
                    width: 100,
                    targets: [1]
                }],
                dom: '<"datatable-header"fl><"datatable-scroll"t><"datatable-footer"ip>',
                language: {
                    search: '<span>Filter:</span> _INPUT_',
                    searchPlaceholder: 'Type to filter...',
                    lengthMenu: '<span>Show:</span> _MENU_',
                    paginate: { 'first': 'First', 'last': 'Last', 'next': $('html').attr('dir') == 'rtl' ? '&larr;' : '&rarr;', 'previous': $('html').attr('dir') == 'rtl' ? '&rarr;' : '&larr;' }
                }
            });

            // Basic datatable
            $('.category-datatable').DataTable();

        };


        return {
            init: function () {
                _componentDatatableBasic();
            }
        }
    }();


    // Initialize module
    // ------------------------------

    document.addEventListener('DOMContentLoaded', function () {
        DatatableBasic.init();
    });
}
if ($('.select').length != 0) {
    var Select2Selects = function () {
        //
        // Setup module components
        //

        // Select2 examples
        var _componentSelect2 = function () {
            if (!$().select2) {
                console.warn('Warning - select2.min.js is not loaded.');
                return;
            }
            // Default initialization
            $('.select').select2({
                minimumResultsForSearch: Infinity
            });
        };
        //
        // Return objects assigned to module
        //
        return {
            init: function () {
                _componentSelect2();
            }
        }
    }();

    // Initialize module
    // ------------------------------

    document.addEventListener('DOMContentLoaded', function () {
        Select2Selects.init();
    });
}
if ($('.delete').length != 0) {
    var SweetAlert = function () {

        var _componentSweetAlert = function () {
            if (typeof swal == 'undefined') {
                console.warn('Warning - sweet_alert.min.js is not loaded.');
                return;
            }

            // Defaults
            var swalInit = swal.mixin({
                buttonsStyling: false,
                confirmButtonClass: 'btn btn-primary',
                cancelButtonClass: 'btn btn-light'
            });

            // Alert combination
            $('.delete').on('click', function () {
                var $this = $(this)
                swalInit({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Yes, delete it!',
                    cancelButtonText: 'No, cancel!',
                    confirmButtonClass: 'btn btn-success',
                    cancelButtonClass: 'btn btn-danger',
                    buttonsStyling: false
                }).then(function (result) {
                    if (result.value) {
                        let id = $this.data('id')
                        $.ajax({
                            type: "get",
                            url: window.location.href + "/delete?id=" + id,
                            dataType: "json",
                            success: function (response) {
                                if (response == "Deleted") {
                                    swalInit(
                                        'Deleted!',
                                        'Your file has been deleted.',
                                        'success'
                                    ).then(function (result) {
                                        $this.parents("tr").remove()
                                    })
                                }
                                else alert(response)

                            },
                            failure: function (response) {
                                alert("failure");
                            },
                            error: function (response) {
                                alert("error");
                            }
                        });


                    }
                    else if (result.dismiss === swal.DismissReason.cancel) {
                        swalInit(
                            'Cancelled',
                            'Your imaginary file is safe :)',
                            'error'
                        );
                    }
                });
            });
        };

        return {
            initComponents: function () {
                _componentSweetAlert();
            }
        }
    }()

    document.addEventListener('DOMContentLoaded', function () {
        SweetAlert.initComponents();
    });
}
if ($('.file-input-slider-main').length!=0) {
    var FileUpload = function () {


        //
        // Setup module components
        //

        // Bootstrap file upload
        var _componentFileUpload = function () {
            if (!$().fileinput) {
                console.warn('Warning - fileinput.min.js is not loaded.');
                return;
            }

            //
            // Define variables
            //

            // Modal template
            var modalTemplate = '<div class="modal-dialog modal-lg" role="document">\n' +
                '  <div class="modal-content">\n' +
                '    <div class="modal-header align-items-center">\n' +
                '      <h6 class="modal-title">{heading} <small><span class="kv-zoom-title"></span></small></h6>\n' +
                '      <div class="kv-zoom-actions btn-group">{toggleheader}{fullscreen}{borderless}{close}</div>\n' +
                '    </div>\n' +
                '    <div class="modal-body">\n' +
                '      <div class="floating-buttons btn-group"></div>\n' +
                '      <div class="kv-zoom-body file-zoom-content"></div>\n' + '{prev} {next}\n' +
                '    </div>\n' +
                '  </div>\n' +
                '</div>\n';

            // Buttons inside zoom modal
            var previewZoomButtonClasses = {
                toggleheader: 'btn btn-light btn-icon btn-header-toggle btn-sm',
                fullscreen: 'btn btn-light btn-icon btn-sm',
                borderless: 'btn btn-light btn-icon btn-sm',
                close: 'btn btn-light btn-icon btn-sm'
            };

            // Icons inside zoom modal classes
            var previewZoomButtonIcons = {
                prev: '<i class="icon-arrow-left32"></i>',
                next: '<i class="icon-arrow-right32"></i>',
                toggleheader: '<i class="icon-menu-open"></i>',
                fullscreen: '<i class="icon-screen-full"></i>',
                borderless: '<i class="icon-alignment-unalign"></i>',
                close: '<i class="icon-cross2 font-size-base"></i>'
            };

            // File actions
            var fileActionSettings = {
                zoomClass: '',
                zoomIcon: '<i class="icon-zoomin3"></i>',
                dragClass: 'p-2',
                dragIcon: '<i class="icon-three-bars"></i>',
                removeClass: '',
                removeErrorClass: 'text-danger',
                removeIcon: '<i class="icon-bin"></i>',
                indicatorNew: '<i class="icon-file-plus text-success"></i>',
                indicatorSuccess: '<i class="icon-checkmark3 file-icon-large text-success"></i>',
                indicatorError: '<i class="icon-cross2 text-danger"></i>',
                indicatorLoading: '<i class="icon-spinner2 spinner text-muted"></i>'
            };


            //
            // Basic example
            //

            $('.file-input-slider-main').fileinput({
                browseLabel: 'Browse',
                browseIcon: '<i class="icon-file-plus mr-2"></i>',
                uploadIcon: '<i class="icon-file-upload2 mr-2"></i>',
                removeIcon: '<i class="icon-cross2 font-size-base mr-2"></i>',
                layoutTemplates: {
                    icon: '<i class="icon-file-check"></i>',
                    modal: modalTemplate
                },
                initialCaption: "No file selected",
                previewZoomButtonClasses: previewZoomButtonClasses,
                previewZoomButtonIcons: previewZoomButtonIcons,
                fileActionSettings: fileActionSettings
            });



            //
            // Misc
            //

            // Disable/enable button
            $('#btn-modify').on('click', function () {
                $btn = $(this);
                if ($btn.text() == 'Disable file input') {
                    $('#file-input-methods').fileinput('disable');
                    $btn.html('Enable file input');
                    alert('Hurray! I have disabled the input and hidden the upload button.');
                }
                else {
                    $('#file-input-methods').fileinput('enable');
                    $btn.html('Disable file input');
                    alert('Hurray! I have reverted back the input to enabled with the upload button.');
                }
            });
        };


        //
        // Return objects assigned to module
        //

        return {
            init: function () {
                _componentFileUpload();
            }
        }
    }();

    // Initialize module
    // ------------------------------

    document.addEventListener('DOMContentLoaded', function () {
        FileUpload.init();
    });
}


$(".status").on("click", function () {
    let $this = $(this)
    let id = $this.data('id')
    $.ajax({
        type: "get",
        url: window.location.href + "/status",
        data: {
            id: id,
        },
        dataType: "json",
        success: function (response) {
            if (response.suc == true) {
                if (response.status == false) {
                    $this.text("Active")
                    $this.removeClass("btn-danger").addClass("btn-success")
                    $this.parents("tr").children(".status-text").text("Disable").removeClass("text-success").addClass("text-danger")
                    
                }
                else {
                    $this.text("Disable")
                    $this.removeClass("btn-success").addClass("btn-danger")
                    $this.parents("tr").children(".status-text").text("Active").removeClass("text-danger").addClass("text-success")
                }
            }
            else {
                alert(response)
            }
        },
        failure: function (response) {
            alert("failure");
        },
        error: function (response) {
            alert("error");
        }
    });
})


