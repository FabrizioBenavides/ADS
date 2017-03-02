// Title: Tigra Calendar PRO
// URL: http://www.softcomplex.com/products/tigra_calendar_pro/
// Version: 1.1 (pop-up mode)
// Date: 06-20-2002 (mm-dd-yyyy)
// Technical Support: support@softcomplex.com (specify product title and order ID)
// Notes: This Script is shareware. Please visit url above for registration details.

var calendars = [];

// Constructor
function calendar (str_date, obj_control, str_min_date, str_max_date) {

	this.popup = cal_popup;

	this.id = calendars.length;
	calendars[this.id] = this;

	if (!obj_control)
		return alert("Form element specified can't be found in the document.");
	this.control_obj = obj_control;
	
	var dt_params = (str_date ? cal_parse_date(str_date) : cal_date_only());
	
	var re_num = /^\-?\d+$/;
	if (str_min_date != null)
		this.min_date = (re_num.exec(str_min_date)
			? new Date (dt_params.valueOf() - new Number(str_min_date * 864e5))
			: cal_parse_date(str_min_date)
		).valueOf();
	if (str_max_date != null)
		this.max_date = (re_num.exec(str_max_date)
			? new Date (dt_params.valueOf() + new Number(str_max_date * 864e5))
			: cal_parse_date(str_max_date)
		).valueOf();

	this.dt_current = dt_params;
}

function cal_popup (num_datetime, b_end) {

	if (num_datetime)
		this.dt_current = new Date(num_datetime);
	else if (this.control_obj.value)
		this.dt_current = cal_parse_date(this.control_obj.value);
	
	this.control_obj.value = cal_generate_date(this.dt_current);
	if (b_end) return;
		
	var obj_calwindow = window.open(
		'calendario.htm?datetime='
		+ this.dt_current.valueOf()
		+ '&id=' + this.id, 'Calendar',
		'width=200,height=196,status=no,resizable=no,top=200,'
		+'left=200,dependent=yes,alwaysRaised=yes'
	);
	obj_calwindow.opener = window;
	obj_calwindow.focus();
}

function cal_date_only (dt_datetime) {
	if (!dt_datetime)
		dt_datetime = new Date();
	dt_datetime.setHours(0);
	dt_datetime.setMinutes(0);
	dt_datetime.setSeconds(0);
	dt_datetime.setMilliseconds(0);
	return dt_datetime;
}
