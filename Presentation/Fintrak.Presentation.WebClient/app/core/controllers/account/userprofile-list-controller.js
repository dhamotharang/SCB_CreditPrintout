/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("UserProfileListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        UserProfileListController]);

    function UserProfileListController($scope, $state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'Core';
        vm.view = 'userprofile-list-view';
        vm.viewName = 'User Profile';
       
        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];
        
        vm.userProfile = {};
        vm.userRoles = [];
        vm.solutionRunDates = [];

        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        vm.showPage = false;

        vm.disablePass = false;


        vm.timeObj = null;



        var initialize = function(){

            if (vm.init === false) {
                //get logged in status.... 
                getUserProfile();
                getUserSolutionRunDates();
                getUserRoles();
               
            }
            
        }

   
        var InitialView = function () {
            //InitialGrid();
        }

        var InitialGrid = function () {
            setTimeout(function () {
                
                // data export
                if ($('#userProfileTable').length > 0) {
                    var exportTable = $('#userProfileTable').DataTable({
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


        var getUserLoggedInStatus = function (loginId) {
            vm.viewModelHelper.apiGet('api/account/firstlogon/' + loginId, null,
            function (result) {
                if (String(result.data).toLowerCase() == "true") {
                    vm.showPage = false;
                } else {
                    vm.showPage = true;
                }
            },
            function (result) {
                toastr.error('Fail to load user data', 'Fintrak');
            }, null);
        }

        var getUserProfile = function () {
            vm.viewModelHelper.apiGet('api/account/getuserprofile', null,
            function (result) {
                vm.userProfile = result.data;
                getUserLoggedInStatus(result.data.LoginID);    //get user loggged in status... 
                //updateaccount();
                //toastr.success('User data loaded, ready for modifiation.', 'Fintrak');
            },
            function (result) {
                toastr.error('Fail to load user data', 'Fintrak');
            }, null);
        }

        var getUserSolutionRunDates = function () {
            vm.viewModelHelper.apiGet('api/solutionrundate/getsolutionrundatebylogin', null,
                  function (result) {
                      vm.solutionRunDates = result.data;
                     
                  },
                   function (result) {
                       toastr.error('Fail to load solution run dates', 'Fintrak');
                   }, null);
        }

        var getUserRoles = function () {
            vm.viewModelHelper.apiGet('api/userrole/getuserrolebylogin', null,
                  function (result) {
                      vm.userRoles = result.data;
                  },
                  function (result) {
                      toastr.error('Fail to load roles', 'Fintrak');
                  }, null);
        }

        var updateaccount = function () {
            vm.viewModelHelper.apiPost('api/account/updateaccount', vm.userProfile,
                function (result) {
                      ///
                  },
                   function (result) {
                       toastr.error('Fail to load user data', 'Fintrak');
                   }, null);
        }

        vm.uploadPhoto = function (input, control) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {

                    //Sets the Old Image to new New Image
                    //$('#photo-id').attr('src', e.target.result);
                    $('#' + control).attr('src', e.target.result);

                    //Create a canvas and draw image on Client Side to get the byte[] equivalent
                    var canvas = document.createElement("canvas");
                    var imageElement = document.createElement("img");

                    imageElement.setAttribute('src', e.target.result);
                    canvas.width = imageElement.width;
                    canvas.height = imageElement.height;
                    var context = canvas.getContext("2d");
                    context.drawImage(imageElement, 0, 0);
                    var base64Image = canvas.toDataURL("image/jpeg");

                    //Removes the Data Type Prefix 
                    //And set the view model to the new value
                    vm.userProfile.Photo = base64Image.replace(/data:image\/jpeg;base64,/g, '');

                    vm.viewModelHelper.apiPost('api/account/updateusersetupprofile', vm.userProfile,
                     function (result) {
                         
                     },
                     function (result) {
                         toastr.error(result.data, 'Fintrak');
                     }, null);
                }

                //Renders Image on Page
                reader.readAsDataURL(input.files[0]);
            }
        };


        vm.password = vm.confirmpass = "";
        vm.strongRegex = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
        vm.mediumRegex = new RegExp("^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})");

        //initialize password x here... 
        vm.passwordStrength = {
            "float": "left",
            "width": "100px",
            "height": "25px",
            "margin-left": "5px"
        };

        vm.analyze = function (value) {
            if (vm.strongRegex.test(value)) {
                vm.passwordStrength["background-color"] = "green";
            } else if (vm.mediumRegex.test(value)) {
                vm.passwordStrength["background-color"] = "orange";
            } else {
                vm.passwordStrength["background-color"] = "red";
            }
        };


        vm.changePassword = function (bool) {

            if (vm.password !== vm.confirmpass) {
                toastr.error("sorry, passwords do not match....", 'Fintrak');
            } else {

                var userObj = {
                    "loginID": vm.userProfile.LoginID,
                    "OldPassword": vm.password,
                    "NewPassword": vm.password
                };

                vm.viewModelHelper.apiPost('api/account/updatePassword/', userObj,  //update the password.... 
                    function (result) {
                        onPassSuccess();                    
                },
                function (result) {
                    toastr.error('Fail to load user data', 'Fintrak');
                }, null);

            }
        }



        var onPassSuccess = function () {

            $state.go('core-userprofile-list', null, { reload: true });
            toastr.success('Password updated successfully...', 'Fintrak');
            $state.go('core-userprofile-list', null, { reload: true });
            //window.location.href = "/Home/Index#/core-userprofile-list";
        }

        initialize();
       
    }
}());
