function PostComment(url,guid,name,email,homepage,content,geturl){

	var username=Cookie.get("username");
	var password=Cookie.get("password");


	var mySlide = new Fx.Slide($('divAll').getElementsByClassName('commentform')[0]);
	mySlide.hide();

	var ajax = new Ajax(url, { 
		data:"username="+escape(username)+"&password="+escape(password)+"&guid="+escape(guid)+"&name="+escape(name)+"&email="+escape(email)+"&homepage="+escape(homepage)+"&content="+escape(content)+"&url="+escape(geturl),
		method: 'post',
		onComplete: function() {

			var s =this.response.text;
			if((s.search("faultCode")>0)&&(s.search("faultString")>0)){
				alert(s.match("<string>.+?</string>")[0].replace("<string>","").replace("</string>",""));
			}
			else{
				$("txaArticle").setProperty("value","");
				//GetComment(geturl);
				InsertComment(this.response.text);
			};

			mySlide.slideIn();
		},
		onCancel: function() {
		}
	}).request();

}

function GetComment(url){
	var ajax = new Ajax(url, {
	method: 'get',
		onComplete: function() {
			InsertComment(this.response.text);
		}
	}).request();
}

function InsertComment(s){
	$('divAll').getElementsByClassName('comments').setOpacity(0);
	$('divAll').getElementsByClassName('comments').setHTML(s);
	var myElementsEffects = new Fx.Elements($('divAll').getElementsByClassName('comments'),{duration:1500});
	myElementsEffects.start({'0': { 'opacity': [0,1]}});
}


function Login(url,username,password){

	var ajax = new Ajax(url, { 
		data:"username="+escape(username)+"&password="+escape(password),
		method: 'post',
		onComplete: function() {

			var s =this.response.text;
			if((s.search("faultCode")>0)&&(s.search("faultString")>0)){
				alert(s.match("<string>.+?</string>")[0].replace("<string>","").replace("</string>",""));
			}
			else{

				Cookie.set('username', username, {duration: 7});
				Cookie.set('password', password, {duration: 7});
				window.location.href=window.location.href;
			};
		},
		onCancel: function() {
		}
	}).request();
}

function Logout(url){

	var username=Cookie.get("username");
	var password=Cookie.get("password");

	var ajax = new Ajax(url, { 
		data:"username="+escape(username)+"&password="+escape(password),
		method: 'post',
		onComplete: function() {

			var s =this.response.text;
			if((s.search("faultCode")>0)&&(s.search("faultString")>0)){
				alert(s.match("<string>.+?</string>")[0].replace("<string>","").replace("</string>",""));
			}
			else{

				Cookie.remove('username');
				Cookie.remove('password');
				window.location.href=window.location.href;
			};
		},
		onCancel: function() {
		}
	}).request();

}


function DelComment(url,guid,geturl){
	
	var username=Cookie.get("username");
	var password=Cookie.get("password");

	var ajax = new Ajax(url, {
	method: 'post',
		data:"username="+escape(username)+"&password="+escape(password)+"&guid="+escape(guid)+"&url="+escape(geturl),
		onComplete: function() {

			var s =this.response.text;
			if((s.search("faultCode")>0)&&(s.search("faultString")>0)){
				alert(s.match("<string>.+?</string>")[0].replace("<string>","").replace("</string>",""));
			}
			else{
				InsertComment(this.response.text);
			};

		},
		onCancel: function() {
		}
	}).request();

}