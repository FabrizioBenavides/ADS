var date_format_capture=""
var date_separator=""
daysMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
daysMonthLeap = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
var iYearInd=-1
var fYearInd=-1
var iMonthInd=-1
var fMonthInd=-1
var iDayInd=-1
var fDayInd=-1
var dteSepInit=-1
var dteSepFin=-1

function isEmptyField(ControlName){
	try{
		var textItem=eval("document.forms[0]."+ControlName);
		return isEmpty(textItem);
		}
	catch(e)
	{alert(ControlName+"\n"+e.value)}
}

	function isEmpty(textItem)
	{	  
	  if( (textItem.value.length==0) || (textItem.value=="") )
	  {
		return true
	  }
	  var kont=0
	  for(i=0; i < textItem.value.length; i++)
	  {
	    if(textItem.value.charAt(i)==" ")
		{
		  kont = kont + 1
		}
	  }
	  if (kont == textItem.value.length)
	  {
	    return true
	  }
	  else
	  {
	      return false
	  }
	}
function validateDate(theObj, format)
{
  date_format_capture=format
  if(isEmpty(theObj))
  {
	  alert("Debe introducir una Fecha Válida")
	  theObj.focus()
	  return false
  }
  date_separator=getDateSeparator()
  processDateIndexes()
  return dateValidator(theObj)
}

function dateValidator(theObj)
{
	var flag		= 0
	var fieldValue 	= theObj.value
	var year	 	= fieldValue.substring(iYearInd,fYearInd)
	var month 		= fieldValue.substring(iMonthInd,fMonthInd)
	var day 		= fieldValue.substring(iDayInd,fDayInd)
	////////
	///////Esta sección se agregó para los casos en que mes o día sea menor de 10
	////////y valide bién el caso de 31/09/03 que no existe
	if(parseInt(day.substring(0,1)) == 0)
    { day = parseInt(day.substring(1,2));  }
    else
    { day= parseInt(day);  }   
    if(parseInt(month.substring(0,1)) == 0)
    { month = parseInt(month.substring(1,2));  }
    else
    { month = parseInt(month);  }   
	////////

	if (fieldValue != "")
	{
	
	  if (fieldValue.length != date_format_capture.length)
	  {
		alert("Incorpore la fecha en un formato válido "+date_format_capture)
		theObj.focus()//gets the focus
		flag=1	
		return false
	  }
	  
	  if((flag==0) && (fieldValue.charAt(dteSepInit)!=date_separator))	
	  {
		alert("Incorpore la fecha en un formato válido "+date_format_capture)
		theObj.focus() //gets the focus
		flag=1
		return false
	  }//if
	  if((flag==0) && (fieldValue.charAt(dteSepFin)!=date_separator))
	  {
		alert("Incorpore la fecha en un formato válido "+date_format_capture)
		theObj.focus()//gets the focus
		flag=1	
		return false
	  }//if	
	  if((flag==0) && (isNaN(year)))
	  {
		alert("Incorpore un año válido")
		theObj.focus()//gets the focus
		flag=1	
		return false
	  }//if
	  if((flag==0) && (year<00))
	  {
		alert("Incorpore un año válido")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if
	  else if((flag==0) && ((year>=00) && (new String(year).length==2))) 
	  {
		  flag=0
	  }
	  else if((flag==0) && ((year==0000) || (year<1900)))
	  {
		alert("Incorpore un año válido")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if
	  if((flag==0) && (isNaN(month)))
	  {
		alert("Incorpore un mes válido ")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if	
	  if((flag==0) && (isNaN(day)))
	  {
		alert("Incorpore un día válido ")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if	
	  if((flag==0) && (month>12))
	  {
		alert("Incorpore un mes válido")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if	
	  if((flag==0) && (month==00))
	  {
		alert("Incorpore un mes válido")
		theObj.focus() //gets the focus
		flag=1	
		return false
	  }//if	
	  if((flag==0) && (day>31))
	  {
		alert("Incorpore un día válido ")
		theObj.focus() //gets the focus
		flag=1
		return false
	  }//if	
	  if((flag==0) && (day==00))
	  {
		alert("Incorpore un día válido ")
		theObj.focus() //gets the focus
		flag=1
		return false
	  }//if	
	  if((flag==0) && (day>getDaysMonthYear(parseInt(month)-1,year)))
	  {
		alert("Incorpore una fecha válida. Día del mes inválido")
		theObj.focus() //gets the focus
		flag=1
		return false
	  }//if
	}//if
	//theObj.value=day+date_separator+month+date_separator+year
	return true	
}// End of dateValidator()

function getDaysMonthYear(mes, anio)
{
	if ((anio % 4) == 0) {
		if ((anio % 100) == 0 && (anio % 400) != 0)
		{
			return daysMonth[mes];
		}
		return daysMonthLeap[mes];
	} else
	{
		return daysMonth[mes];
	}
}

function getDateSeparator()
{
	var sep=""
	if(date_format_capture.indexOf("-")==-1)
	{
		sep="\/"
	}
	else
	{
		sep="-"
	}
	return sep
}

function processDateIndexes()
{
	var auxFormat=date_format_capture
	var auxInit=0
	var auxEnd=0
	var auxSub=""

	auxEnd=auxFormat.indexOf(date_separator,auxInit)
	auxSub=auxFormat.substring(auxInit,auxEnd)
	dteSepInit=auxEnd
	updateIndexes(auxSub,auxInit,auxEnd)
	auxInit=auxEnd+1

	auxEnd=auxFormat.indexOf(date_separator,auxInit)
	auxSub=auxFormat.substring(auxInit,auxEnd)
	dteSepFin=auxEnd
	updateIndexes(auxSub,auxInit,auxEnd)
	auxInit=auxEnd+1

	auxSub=auxFormat.substring(auxInit,auxFormat.length)
	updateIndexes(auxSub,auxInit,auxFormat.length)
}

function updateIndexes(dateItem, iInd, fInd)
{
	switch(dateItem.toUpperCase())
	{
		case "YYYY":
		            iYearInd=iInd
			        fYearInd=fInd
		            break;
		case "YY":
		            iYearInd=iInd
			        fYearInd=fInd
		            break;
		case "DD":
		            iDayInd=iInd
			        fDayInd=fInd
		            break;
		case "MM":
		            iMonthInd=iInd
			        fMonthInd=fInd
		            break;
	}
}


	function validateDateRange(min,max,ctrlDate,format)
	{
		date_format_capture=format
		date_separator=getDateSeparator()
		processDateIndexes()
		var minDate = getDateObj(min)
		var maxDate = getDateObj(max)
		var dateToValidate = getDateObj(ctrlDate.value)
		if(validateMinDate(dateToValidate,minDate))
		{
			if(validateMaxDate(dateToValidate,maxDate))
			{
				return true
			}
			else
			{
				return false
			}
		}
		else
		{
			return false
		}
	}

	function validateMinDate(dateToValidate,minDate)
	{
		if (dateToValidate.getYear() > minDate.getYear())
		{ return true; }
		else
		{ 
			if (dateToValidate.getYear() == minDate.getYear())
			{
				if (dateToValidate.getMonth() > minDate.getMonth())
				{ return true; }
				else
				{
					if (dateToValidate.getMonth() == minDate.getMonth())
					{
						if (dateToValidate.getDate() >= minDate.getDate())
						{ return true; }
						else
						{ return false; }
					}
				}
			}
		}
		return false;
	}

	function validateMaxDate(dateToValidate,maxDate)
	{
		if (dateToValidate.getYear() < maxDate.getYear())
		{ return true; }
		else
		{ 
			if (dateToValidate.getYear() == maxDate.getYear())
			{
				if (dateToValidate.getMonth() < maxDate.getMonth())
				{ return true; }
				else
				{
					if (dateToValidate.getMonth() == maxDate.getMonth())
					{
						if (dateToValidate.getDate() <= maxDate.getDate())
						{ return true; }
						else
						{ return false; }
					}
				}
			}
		}
		return false;
	}

	function getDateObj(strDate)
	{
		var fieldValue 	= strDate
		var year
		if(fieldValue.length>=10)
		{
			if((fYearInd-iYearInd)>2)
			{
				year = fieldValue.substring(iYearInd,fYearInd)
			}
			else
			{
				year = fieldValue.substring((iYearInd+2),(fYearInd+2))
			}
		}
		else
		{
			year = fieldValue.substring(iYearInd,fYearInd)
		}
		var month 		= fieldValue.substring(iMonthInd,fMonthInd)
		var day 		= fieldValue.substring(iDayInd,fDayInd)					
		
		return  new Date(parseInt(year*1),parseInt(month*1)-1,parseInt(day*1))
	}

//elongoria Code 21/Sep/04
//Valida que la fecha de fin no sea ni mayor ni igual que la fecha de inicio (compareTwoDates)
function validateStartAndEndDate(startDateCtrl, EndDateCtrl,format)
{
date_format_capture=format
date_separator=getDateSeparator()
processDateIndexes()
var sCrtl=getInputObjectV(startDateCtrl);
var eCrtl=getInputObjectV(EndDateCtrl);
	
var sdte = getDateObj(sCrtl.value);
var edte = getDateObj(eCrtl.value);	
if (compareTwoDates(sdte,edte)==true)
{	
	eCrtl.focus();
	return false;
}
return true;
}

//elongoria Code 21/Sep/04
//Valida que la fecha de fin no sea ni mayor ni igual que la fecha de inicio (validateStartAndEndDate)
function compareTwoDates(sdate,edate)
	{
		if (sdate.getYear() > edate.getYear())
		{ return true; }
		else
		{ 
			if (sdate.getYear() == edate.getYear())
			{
				if (sdate.getMonth() > edate.getMonth())
				{ return true; }
				else
				{
					if (sdate.getMonth() == edate.getMonth())
					{
						if (sdate.getDate() > edate.getDate())
						{ return true; }
						else
						{ return false; }
					}
				}
			}
		}
		return false;
	}

//elongoria   21/Sep/04
function getInputObjectV(complexName)
{
	var formObj = eval("document.forms[0]." + getObjNameV(complexName));
	return formObj
}

function getObjNameV(complexName)
{
		elements = document.forms[0].getElementsByTagName("input");
		formName = document.forms[0].id;
		for(i=0; i<elements.length; i++)
		{
			if(elements[i].id.indexOf(complexName)>=0)
			{	complexName = elements[i].id;	}
		}	
		return complexName
}	
