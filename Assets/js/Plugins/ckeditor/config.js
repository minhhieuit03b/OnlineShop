/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';;
    // config.uiColor = '#AADC6E';
    //Config.ProcessHTMLEntities = false;
    //config.htmlEncodeOutput = true;
    config.ForceSimpleAmpersand = true;
    //config.ValidateRequest = false;
    config.entities = false;
    config.entities_latin = false;
    config.ForceSimpleAmpersand = true;
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language =  'vi';
    config.filebrowserBrowseUrl = '/Assets/js/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/js/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Assets/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Assets/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Assets/js/plugins/ckfinder/');
    
};
