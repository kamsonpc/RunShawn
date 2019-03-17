const MenuSettingsController = {
    editor: null,
    getDataUrl: "",
    saveSettingsUrl: "",
    init: function () {
        this.editor = new MenuEditor('myEditor', { listOptions: sortableListOptions, iconPicker: iconPickerOptions });

        var iconPickerOptions = { searchText: "Wyszukaj...", labelHeader: "{0}/{1}" };
        var sortableListOptions = {
            placeholderCss: { 'background-color': "#cccccc" }
        };
               
        this.editor.setForm($('#add-menu-item'));
        this.editor.setUpdateButton($('#btnUpdate'));
        this.loadData();
    },
    loadData: function () {
        var list = this.editor;
        $.ajax({
            url: this.getDataUrl,
            method: "Get",
            success: function (data) {
                $(function () {
                    list.setData(data);
                });

            }
        });
    },
    saveSettings: function () {
        var ctrl = this;
        $('#save').on('click', function () {
            $.ajax({
                url: ctrl.saveSettingsUrl,
                method: "Post",
                data: ctrl.editor.getString(),
                dataType: "json",
                traditional: true,
                success: function (data) {
                    if (data)
                        alert("zapisano");
                    else
                        alert("bład");
                }
            });
        });
    },
    addNewMenuItem: function () {
         var ctrl = this; 
        $("#add-menu-item").submit(function (e) {
            var form = $(this);
            var url = form.attr('action');

            $.ajax({
                type: "POST",
                url: url,
                data: form.serialize(),
                success: function () {
                    ctrl.loadData();
                }
            });
            e.preventDefault();
        });
    }
};