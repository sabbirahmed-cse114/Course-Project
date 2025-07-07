$(function () {
    let selectedTags = [];

    function renderSelectedTags() {
        $('#selectedTags').empty();
        $('#hiddenTagInputs').empty();

        $.each(selectedTags, function (index, tag) {
            let badge = $('<span class="badge bg-secondary text-light fs-6 d-inline-flex align-items-center"></span>')
                .text(tag.label)
                .append(
                    $('<button type="button" class="btn-close btn-close-white ms-2" aria-label="Remove"></button>')
                        .attr('data-id', tag.id)
                );

            $('#selectedTags').append(badge);

            let hidden = $('<input>').attr({
                type: 'hidden',
                name: 'TagIds',
                value: tag.id
            });
            $('#hiddenTagInputs').append(hidden);
        });
    }

    $('#TagIds').autocomplete({
        source: '/Admin/Template/GetTagsByAutocompleteSearch',
        minLength: 1,
        select: function (event, ui) {
            let exists = selectedTags.some(t => t.id === ui.item.id);
            if (!exists) {
                selectedTags.push({ id: ui.item.id, label: ui.item.label });
                renderSelectedTags();
            }
            $('#TagIds').val('');
            return false;
        }
    });

    $('#selectedTags').on('click', '.btn-close', function () {
        let tagId = $(this).data('id');
        selectedTags = selectedTags.filter(t => t.id !== tagId);
        renderSelectedTags();
    });
});