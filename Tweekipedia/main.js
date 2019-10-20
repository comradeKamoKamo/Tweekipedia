//Global
let tweet_title;


function input_event() {
    const wiki_url = document.getElementById("wikiurl_text").value;
    if (wiki_url == null || wiki_url == "") return;

    const pattern = /^(http:\/\/|https:\/\/).+(\.wikipedia.org\/wiki\/){1}.+$/;
    const result = wiki_url.match(pattern);

    if (result != null) {
        if (result.length == 3) {
            let lang = wiki_url.substring(result[1].length);
            lang = lang.substring(0, lang.indexOf("."));
            let title = wiki_url.substring(result[1].length + lang.length + result[2].length);
            if (title.substring(0, 2) == "i/") {
                //モバイル版URL
                title = title.substring(2);
            }

            document.getElementById("copy_text").value =
                "https://tweekipedia.azurewebsites.net/?lang=" + lang +
                "&title=" + title;
            tweet_title = title.replace("_", " ");
            input_error(false);
        } else {
            input_error(true);
        }
    } else {
        const p2 = /^(http:\/\/|https:\/\/).+(\.wikipedia.org\/){1}$/
        const r2 = wiki_url.match(p2);
        if (r2 == null) {
            input_error(true);
            return;
        }
        if (r2.length == 3) {
            let lang = wiki_url.substring(r2[1].length);
            lang = lang.substring(0, lang.indexOf("."));
            let title = "Wikipedia"

            document.getElementById("copy_text").value =
                "https://tweekipedia.azurewebsites.net/?lang=" + lang +
                "&title=";
            tweet_title = "";
            input_error(false);
        } else {
            input_error(true);
        }
    }

}

function input_error(onoff) {
    if (onoff) {
        document.getElementById("input_error_span").style = "";
        document.getElementById("copy_btn").disabled = true;
        document.getElementById("tweet").disabled = true;
        document.getElementById("tweet").style = "background-color:gray;"
    } else {
        document.getElementById("input_error_span").style = "display:none;";
        document.getElementById("copy_btn").disabled = false;
        document.getElementById("tweet").disabled = false;
        document.getElementById("tweet").style = "background-color:#55acee;";
    }
}

function copy_event() {
    const textbox = document.getElementById("copy_text");
    if (textbox.value == "") return;
    textbox.select();
    document.execCommand("copy");
    document.getElementById("copy_done_span").style = "";
}

function tweet() {
    const url = document.getElementById("copy_text").value;
    if (url == "" || tweet_title == null) return;
    let tweet_url = "https://twitter.com/intent/tweet"
    let text = ""
    if (tweet_title != "") {
        text = decodeURIComponent(tweet_title) + "- Wikipedia via @tweekipedia_ " + url;
    } else {
        text = "Wikipedia via @tweekipedia_ " + url;
    }

    tweet_url += "?text=" + encodeURIComponent(text);

    open(tweet_url, "_blank");
}