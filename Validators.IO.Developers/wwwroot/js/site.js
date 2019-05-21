$(".copy").on("click", function (event) {
	var copyElement = $(this).data("copy-id");
	CopyToClipboard($("#" + copyElement).text());
});


function CopyToClipboard(text) {

	const textarea = document.createElement('textarea');

	textarea.value = text;

	textarea.setAttribute('readonly', '');

	textarea.style.position = 'absolute';
	textarea.style.left = '-9999px';

	document.body.appendChild(textarea);

	textarea.select();

	try {
		document.execCommand('copy');
	} catch (err) {
		alert(err);
	}

	textarea.remove();
}
