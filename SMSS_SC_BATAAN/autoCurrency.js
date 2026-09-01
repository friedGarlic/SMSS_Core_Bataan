// JScript File

/* This script and many more are available free online at
The JavaScript Source!! http://javascript.internet.com
Created by: Pavel Donchev | http://chameleonbulgaria.com/ */

function currency(which) {
    currencyValue = which.value;
    currencyValue = currencyValue.replace(",", "");
    decimalPos = currencyValue.lastIndexOf(".");
    if (decimalPos != -1) {
        decimalPos = decimalPos + 1;
    }
    if (decimalPos != -1) {
        decimal = currencyValue.substring(decimalPos, currencyValue.length);
        if (decimal.length > 2) {
            decimal = decimal.substring(0, 2);
        }
        if (decimal.length < 2) {
            while (decimal.length < 2) {
                decimal += "0";
            }
        }
    }
    if (decimalPos != -1) {
        fullPart = currencyValue.substring(0, decimalPos - 1);
    } else {
        fullPart = currencyValue;
        decimal = "00";
    }
    newStr = "";
    for (i = 0; i < fullPart.length; i++) {
        newStr = fullPart.substring(fullPart.length - i - 1, fullPart.length - i) + newStr;
        if (((i + 1) % 3 == 0) & ((i + 1) > 0)) {
            if ((i + 1) < fullPart.length) {
                newStr = "," + newStr;
            }
        }
    }
    which.value = newStr;
}

function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
    alert(num);
    return (((sign) ? '' : '-') + '' + num + '.' + cents);
   
}

function normalize(which) {
    alert("Normal");
    val = which.value;
    val = val.replace(",", "");
    which.value = val;
}



/* This script and many more are available free online at
The JavaScript Source!! http://javascript.internet.com
Created by: Corneliu Lucian 'Kor' Rusu | corneliulucian[at]gmail[dot]com */
var r = {
    'special': /[\W]/g,
    'quotes': /['\''&'\"']/g,
    'notnumbers': /[^\d]/g
}

function valid(o, w) {
    o.value = o.value.replace(r[w], '');
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode <= 46 || charCode > 57))
        return false;
    return true;
}
function isNumericKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var dot = 0;
    if (charCode > 31 && (charCode <= 46 || charCode > 57)) {
        return false;
    }
    dot = (charCode == 110) ? 0 : 1;
    if (dot == 1) {
        return false;
    }
    return true;
}
function CurrencyFormatted(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    i = parseInt((i + .005) * 100);
    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}
// number formatting function
// copyright Stephen Chapman 24th March 2006, 22nd August 2008
// permission to use this function is granted provided
// that this copyright notice is retained intact

function formatNumber(num, dec, thou, pnt, curr1, curr2, n1, n2) {
    var x = Math.round(num * Math.pow(10, dec));
    if (x >= 0) n1 = n2 = ''; var y = ('' + Math.abs(x)).split('');
    var z = y.length - dec;
    if (z < 0) z--; for (var i = z; i < 0; i++) y.unshift('0');
    if (z < 0) z = 1; y.splice(z, 0, pnt);
    if (y[0] == pnt) y.unshift('0');
    while (z > 3) {
        z -= 3;
        y.splice(z, 0, thou);
    }
    var r = curr1 + n1 + y.join('') + n2 + curr2;
    return r;
}
function GetRadioButtonValue(id) {

    var radio = document.getElementsByName(id);

    for (var j = 0; j < radio.length; j++) {
        if (radio[j].checked)
            return radio[j].value;
    }
}

function numericKeyPress(evt, ctlName, explen, decLen) {
    var cntNbr = document.getElementById(ctlName.id).value;
    var isDot = 0;
    if (57 < event.keyCode || event.keyCode < 48)
        evt.returnValue = false;
    else {
        for (var i = 0; i <= (cntNbr.length - 1); i++) {
            if (cntNbr.charAt(i) == ".")
                isDot = 1;
        }
        if (isDot == 0) {
            var beforeDec = cntNbr;

            if (beforeDec.length >= explen) {
                document.getElementById(ctlName.id).value = cntNbr.substring(0, cntNbr.length - 1)

            }
            evt.returnValue = true;
        }
        else {
            var afterDec = (cntNbr.split(".", 2)).pop();

            if (afterDec.length >= decLen) {
                document.getElementById(ctlName.id).value = cntNbr.substring(0, cntNbr.length - 1)
                evt.returnValue = true;
            }
        }
    }
    if (event.keyCode == 46) {
        for (var i = 0; i <= (cntNbr.length - 1); i++) {
            if (cntNbr.charAt(i) == ".")
                isDot = 1;
        }

        if (isDot == 0)
            evt.returnValue = true;
    }

}

/* This script and many more are available free online at
The JavaScript Source!! http://javascript.internet.com
Created by: Mario Costa |  */
function currencyFormat(fld, milSep, decSep, e) {
    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';
    var whichCode = (window.Event) ? e.which : e.keyCode;

    if (whichCode == 13) return true;  // Enter
    if (whichCode == 8) return true;  // Delete
    key = String.fromCharCode(whichCode);  // Get key value from key code
    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
    len = fld.value.length;
    for (i = 0; i < len; i++)
        if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(fld.value.charAt(i)) != -1) aux += fld.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0) fld.value = '';
    if (len == 1) fld.value = '0' + decSep + '0' + aux;
    if (len == 2) fld.value = '0' + decSep + aux;
    if (len > 2) {
        aux2 = '';
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += milSep;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }
        fld.value = '';
        len2 = aux2.length;
        for (i = len2 - 1; i >= 0; i--)
            fld.value += aux2.charAt(i);
        fld.value += decSep + aux.substr(len - 2, len);
    }
    return false;
}

function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + '' + num + '.' + cents);
}