const ScoresController = {
    addScoresUrl: "",
    removeScoresUrl: "",
    editScore: function () {
        $(".edit-button").click(function () {
            var id = this.id;
            var points = $(this).parent().siblings(".points").html();
            $('#scores-edit-modal').modal('show');
            $("#count").val(points);
            $('#userId').val(id);
        });
    },
    editScoreSubmit: function () {
        $("#scores-edit-modal").on("submit", "#change-scores-form", function (e) {
            e.preventDefault();
            var form = $(this);
            $.ajax({
                url: form.attr("action"),
                method: form.attr("method"),
                data: form.serialize(),
                success: function () {
                    $('#scores-edit-modal').modal('hide');
                    $("#" + $('#userId').val()).parent().siblings(".points").html($("#count").val());
                }
            });
        });
    }
};