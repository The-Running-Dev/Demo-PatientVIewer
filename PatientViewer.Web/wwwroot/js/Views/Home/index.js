$(document).ready(function () {
	$('#sampleTable').DataTable();

	// Hide the items per page selector
	$('.dataTables_length').hide();

	// Move the pager to the top
	$("#sampleTable_wrapper .row:first-child").after($('#sampleTable_wrapper .row:last-child'));
});