// --------------------------------------------------------------------------------
// Date Parser/Generator for Tigra Calendar PRO script
// Format: dd-mm-yyyy
// If you can't find desired format here - mail us and we'll create one

// string to date object converter. input format is dd-mm-yyyy
// this method may be customized - string date format
function cal_parse_date (str_date) {
	var re_date = /^(\d+)\/(\d+)\/(\d+)$/;
	if (!re_date.exec(str_date))
		return alert("Parsing error: unsupported date format '" + str_date + "'");
	return (new Date (RegExp.$3, RegExp.$2-1, RegExp.$1));
}

// date object to string converter, output format is dd-mm-yyyy
// this method may be customized - string date format
function cal_generate_date (dt_date) {
	return (
		new String (
			(dt_date.getDate() < 10 ? '0' : '') + dt_date.getDate() + "/"
			+ (dt_date.getMonth() < 9 ? '0' : '') + (dt_date.getMonth() + 1) + "/"
			+ dt_date.getFullYear()
		)
	);
}

// --------------------------------------------------------------------------------

