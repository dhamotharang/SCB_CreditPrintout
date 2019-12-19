/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("RunUploadListController",
                    ['$scope', '$window', '$state', '$http', '$parse', 'viewModelHelper', 'validator',
                        RunUploadListController]);

    function RunUploadListController($scope, $window, $state, $http, $parse, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;
       
        vm.module = 'Core';
        vm.view = 'runupload-list-view';
        vm.viewName = 'Run Uploads';
        vm.solutions = [];

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];
        vm.status = 'false'
        vm.verifyMsg = '';

        //vm.selectedSolutionId = 2;



        ///////////////////////////////defined variables... 
        vm.showUploadBtn = true;

        vm.opType = '';
        vm.uploadOpts = [];

        //uploadstatus 
        vm.uplstatus = 'please select an option';
        vm.uploadedItems = vm.pendingItems = "";
        vm.isUpdated = false;

        vm.onChangeOperationType = function () {

            if (Number(vm.opType) === 1) {
                vm.showUploadBtn = true;
                updateUploadStatus();
            } else {
                vm.isUpdated = false;
                vm.showUploadBtn = false;

            }

            //retrieve all upload options... 

            vm.uploadOpts = [];
            vm.viewModelHelper.apiGet('api/runupload/getuploadwithoptions/' + vm.opType, null,
            function (result) {
                console.log(result.data);


                var all = result.data;
                for (var i = 0; i < all.length; i++) {
                    vm.uploadOpts.push({ 'uploadId':all[i].Key, 'name': all[i].Value, 'title': all[i].Value });
                }
            },
            function (result) {
                toastr.error('Fail to run upload', 'Fintrak Error');
            }, null);

        }


            
        vm.csv = {
            uploadId: 0,
            content: null,
            header: true,
            headerVisible: false,
            separator: ',',
            separatorVisible: false,
            result: null,
            encoding: 'ISO-8859-1',
            encodingVisible: true,
            Truncate: false,
            PostUploadAction: false
        };

        vm.init = false;
        vm.showInstruction = true;
        vm.instruction = 'Only CSV formated files can be uploaded';
  
               
        var initialize = function () {

            if (vm.init === false) {
                initializeUploads();
            }
        };

        var initializeUploads = function () {
            getUploads();
            getSolutions();
            getUploadsbySolution(2)

        };

        var InitialView = function () {
            InitialGrid();
        };

        var InitialGrid = function () {
            setTimeout(function () {

                // data export
                if ($('#runuploadTable').length > 0) {
                    var exportTable = $('#runuploadTable').DataTable({
                        "lengthMenu": [[20, 50, 50, 100, -1], [20, 50, 50, 100, "All"]],
                        sDom: "T<'clearfix'>" +
                            "<'row'<'col-sm-6'l><'col-sm-6'f>r>" +
                            "t" +
                            "<'row'<'col-sm-6'i><'col-sm-6'p>>",
                        "tableTools": {
                            "sSwfPath": "app/assets/js/plugins/datatable/exts/swf/copy_csv_xls_pdf.swf"
                        }
                    });
                }
            }, 50);
        }

        vm.uploadClicked = function () {
            var fileopen = $("#fileUpload");
            fileopen.clearInputs(true)
            //clone = fileopen.clone(true);

            //fileopen.replaceWith(clone);
        }

        vm.alowUpload = function () {
            if (vm.csv.content !== null && vm.csv.uploadId > 0)
                return false;
            return true;
        }






        vm.onUploadChanged = function (uploadId) {
            console.log(uploadId);
           // alert("uploadid is = " + uploadId.uploadId);

            vm.csv.content = null;
            vm.showInstruction = true;

            //if (uploadId == 25) {

            //    vm.viewModelHelper.apiGet('api/runupload/checkunposted', null,
            //        function (result) {
            //            vm.uploadResults = result.data.DataTable.length;
            //            toastr.success(vm.template.Title + ' uploaded successfully.', 'Fintrak Upload');
            //        },
            //        function (result) {
            //            toastr.error('Fail to run upload', 'Fintrak Error');
            //        }, null);
            //} else {
            //    toastr.warning('Please select the file to upload.', 'Fintrak Warning');
            //}

            vm.viewModelHelper.apiGet('api/upload/getupload/' + uploadId.uploadId, null,
                   function (result) {
                       vm.template = result.data;
                       vm.sppVerify = vm.template.Verification;
                       vm.uploadResults = '';
                                    
                       if (vm.template.Verification === null)
                       {
                           vm.status = 'false';
                       }
                       else {
                           vm.status = 'true';
                       }
                       //Adjustment upload id
                       if (uploadId == 1020) {
                       
                           toastr.info('Kindly use the Verify Button to check for Un-posted Adjustment.</br> and to also enable the Upload Button ', 'Unposted Adjustment Check');
                         
                           vm.alowUpload = function () {
                               return true;
                           }
                       }
                       else {
                           vm.instruction = 'Upload template for ' + result.data.Title + '<br\>' + result.data.Template + '.';
                           toastr.info(vm.instruction, 'Fintrak Upload');
                           vm.alowUpload = function () {
                               return false;
                           }
                       }
                       
                   },
                   function (result) {
                       toastr.error('Fail to load upload template', 'Fintrak Error');
                   }, null);
        }



        var _lastGoodResult = '';
        vm.toPrettyJSON = function (json, tabWidth) {
            var objStr = JSON.stringify(json);
            var obj = null;
            try {
                obj = $parse(objStr)({});
            } catch (e) {
                // eat $parse error
                return _lastGoodResult;
            }

            var result = JSON.stringify(obj, null, Number(tabWidth));
            _lastGoodResult = result;

            return result;
        };

        vm.runUpload = function () {

            vm.uploadResults = [];
            var csvModel = {
                UploadId: vm.csv.uploadId.uploadId,
                Content: vm.csv.content,
                Header: vm.csv.header,
                Separator: vm.csv.separator,
                Truncate: vm.csv.Truncate,
                PostUploadAction: vm.csv.PostUploadAction
            };

            if (vm.csv.content !== null) {

                vm.viewModelHelper.apiPost('api/runupload/uploadcsv', csvModel,
                    function (result) {
                        //update uploadstatus  table
                        ///vm.updateStatusDataUpload(csvModel.UploadId);

                        vm.uploadResults = result.data;
                        toastr.success(vm.template.Title + ' uploaded successfully.', 'Fintrak Upload');
                        vm.alowUpload = function () {
                            return true;
                        }
                        vm.csv.uploadId = 0;
                    },
                    function (result) {
                        toastr.error('Fail to run upload', 'Fintrak Error');
                    }, null);
            } else {
                toastr.warning('Please select the file to upload.', 'Fintrak Warning');
            }                     

        }


        vm.updateStatusDataUpload = function () {
            vm.viewModelHelper.apiGet('api/updatestatus/updateStatusObjValue/' + vm.csv.uploadId.uploadId, null,
            function (result) {
                //vm.uploadResults = result.data;
                toastr.success(' Process executed successfully.', 'Fintrak Process');
            },
            function (result) {
                toastr.error('Fail to run upload', 'Fintrak Error');
            }, null);
        }

        vm.runProcess = function () {
            vm.uploadResults = [];
            vm.viewModelHelper.apiGet('api/runupload/ProcessRunJob/' + vm.csv.uploadId.uploadId,  null,
                function (result) {
                    //vm.uploadResults = result.data;
                    toastr.success(' Process executed successfully.', 'Fintrak Process');                    
                },
                function (result) {
                    toastr.error('Fail to run upload', 'Fintrak Error');
                }, null);

        };



        var updateUploadStatus = function () {
            
            vm.viewModelHelper.apiGet('api/uploadstatus/getalluploadstatus', null,
             function (result) {
                 vm.isUpdated = true;

                 var all = result.data;

                 var pItems = "";
                 var uItems = "";

                 vm.status = 'false';

                 for (var ig = 0; ig < all.length; ig++) {

                     if (all[ig].Status == false) {
                         pItems += '<div class="alert alert-danger" style="margin:1px 0px">' + all[ig].UploadItem + '</div>';
                     } else {
                         uItems += '<div class="alert alert-info" style="margin:1px 0px">' + all[ig].UploadItem + '</div>';
                     }

                 }

                 vm.pendingItems = pItems;
                 vm.uploadedItems = uItems;
                },

            function (result) {
                toastr.error('Unable to load retrieve upload statuses', 'Fintrak Error');
                }, null);

        }



        var getUploads = function () {
            vm.viewModelHelper.apiGet('api/upload/getuploads', null,
            function (result) {
                vm.uploads = result.data;
                vm.status = 'false';
            },
            function (result) {
                toastr.error('Unable to load upload templates', 'Fintrak Error');
            }, null);
        }

        var getSolutions = function () {
            vm.viewModelHelper.apiGet('api/solution/availablesolutions', null,
            function (result) {
                vm.solutions = result.data;
                vm.init === true;

            },
            function (result) {
                toastr.error(result.data, 'Fintrak');
            }, null);
        }

        vm.onSolutionChanged = function (solutionId) {
            getUploadsbySolution(solutionId);
        }

        var getUploadsbySolution = function (solutionId) {
            vm.viewModelHelper.apiGet('api/runupload/getuploadbysolution/' + solutionId, null,
            function (result) {
                vm.uploads = result.data;
            },
            function (result) {
                vm.uploads = [];
                toastr.error('Fail to load Template.', 'Fintrak');

            }, null);
        }

        vm.verify = function () {
            vm.viewModelHelper.apiGet('api/runupload/verify/' + vm.sppVerify, null,
                   function (result) {
                     
                       vm.uploadResults = result.data;
                       if (vm.csv.uploadId == 1020 && result.data[0].Message == "0")
                       {
                           toastr.error('There are no Un-posted Adjustment.', 'Fintrak');
                           vm.status = 'false';
                           vm.alowUpload = function () {
                               return false;
                              
                           }
                       }
                       else {
                          // toastr.error('There are yet to be Posted Adjustment </br> kindly post before uploading a new adjustment', 'Fintrak');
                           toastr.error('There are yet to be Posted Adjustment </br> kindly post before uploading a new adjustment', 'Un-posted Adjustment Check', { timeOut: 0, extendedTimeOut: 0, closeButton: true, tapToDismiss: false });

                       }

                      
                   },
                   function (result) {
                       toastr.error('Unable to load upload templates', 'Fintrak Error');
                   }, null);
        }
        initialize();
    }
}());
