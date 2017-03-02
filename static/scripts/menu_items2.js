function imgTxt (image,wd,hd,txt)
	{
	return '<img src="'+image+'" width="'+wd+'" height="'+hd+'">'+txt;
	}

var MENU_ITEMS2 = 
	[ // nivel 0 elemento 0
		[ // caption
			[	imgTxt('../static/images/menu0_r1_c1.gif','65','19',''),
                imgTxt('../static/images/menu0_r1_c1.gif','65','19',''),			
				imgTxt('../static/images/menu0_r1_c1_f2.gif','65','19',''),
				imgTxt('../static/images/menu0_r1_c1_f2.gif','65','19','')
			],null,null,
			// link			
		// subitems		    
            ['Intraben','javascript:var x = window.open(\'http://intraben.fasa.com.mx\',\'\',\'menubar=yes,status=yes,toolbar=yes,resizable=yes,location=yes,scrollbars=yes,width=640,height=520,top=0,left=0\')'],
            ['Portal RH','javascript:var x = window.open(\'http://portalbenavides\',\'\',\'menubar=yes,status=yes,toolbar=yes,resizable=yes,location=yes,scrollbars=yes,width=640,height=520,top=0,left=0\')'],            
			['General','javascript:var x = window.open(\'../static/Help/AyudaGeneral.htm\',\'\',\'menubar=no,status=no,toolbar=no,resizable=yes,location=no,scrollbars=yes,width=620,height=500,top=0,left=0\')'],
			['Medicinas','CCRedirectorPOSAdmin.aspx?strPageName=AyudaMedicinas.aspx'],
			['Dolencias','CCRedirectorPOSAdmin.aspx?strPageName=AyudaDolencias.aspx'],			
	    ]	
];

