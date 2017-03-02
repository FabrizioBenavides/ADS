
function CheckOptionButton(objControl, strValueToBeChecked) {
  var intCounter = 0;
  if (objControl != null) {
    if (objControl.length != null) {
      for (intCounter = 0; intCounter < objControl.length; intCounter++) {
        if (objControl[intCounter].value == strValueToBeChecked) {
          objControl[intCounter].checked = true;
          break;
        }
      }
    } else {
      if (objControl.value == strValueToBeChecked) {
        objControl.checked = true;
      }
    }
  }
}

function SelectComboBoxElement(objControl, strValue) {
  var intCounter = 0;
  if (objControl != null) {
    if (objControl.options.length != null) {
      for (intCounter = 0; intCounter < objControl.options.length; intCounter++) {
        if (objControl.options[intCounter].value == strValue) {
          objControl.options[intCounter].selected = true;
          break;
        }
      }
    }
  }
}

function DeleteComboBoxElements(objControl, intControlLength) {
  if (objControl != null) {
    if (objControl.options.length != null) {
      objControl.options.length = intControlLength;
    }
  }
}

function SelectAllComboBoxElements(objControl, blnSelectElements) {
  if (objControl != null) {
    if (objControl.options.length != null) {
      for (var intCounter = 0; intCounter < objControl.length; intCounter++) {
        objControl.options[intCounter].selected = blnSelectElements;
      }
    }
  }
}

function blnComboBoxHasAnElementSelected(objControl) {
  var blnSelected = false;
  if (objControl != null) {
    if (objControl.options.length != null) {
      for (var intCounter = 0; intCounter < objControl.length; intCounter++) {
        blnSelected = objControl.options[intCounter].selected;
        if (blnSelected == true) {
          break;
        }
      }
    }
  }
  return(blnSelected);
}

function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(j, s.length);
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(0, j+1);
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}
