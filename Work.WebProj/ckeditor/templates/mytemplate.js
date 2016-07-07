//加入template
CKEDITOR.addTemplates(
'default',
{
    //圖片資料夾路徑，放在同目錄的images資料夾內
    imagesPath: CKEDITOR.getUrl('/Scripts/ckeditor/templates/images/'),
    templates: [
    {
        
        title: 'MyTemplate1',   //標題
        image: 'template5.png', //圖片
        description: '我的Coding之路御用版型', //樣板描述
        //自訂樣板內容
        html: '<h3>我的標題</h3>'+
              '<p>Type the text here</p>' +
              '<div><img src="/images/testpic.png" />' +
              '</div>'  
    },
    //第二個樣板
    {
        title: 'MyTemplate2',
        image: 'template4.png',
        description: '測試版型',
        html: '<table cellspacing="0" cellpadding="0" style="width:100%" border="0">'+
              '<tr><td style="width:50%"><h3>Title 1</h3></td>'+
              '<td></td><td style="width:50%"><h3>Title 2</h3></td>'+
              '</tr><tr><td>Text 1</td><td></td><td>Text 2</td></tr></table>'+
              '<p>More text goes here.</p>'
    }
    ]
});