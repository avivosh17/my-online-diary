import { send } from "../utilities";

let savebutton = document.querySelector("#savebutton") as HTMLButtonElement;
let diarypage1 = document.querySelector("#diarypage1") as HTMLTextAreaElement;
let diarypage2 = document.querySelector("#diarypage2") as HTMLTextAreaElement;
let title = document.querySelector("#title") as HTMLDivElement;

let userid = localStorage.getItem("userid");
let username = await send("getusername", userid);
let d1 = await send("loaddiary2", userid);
let d2 = await send("loaddiary", userid);
diarypage2.innerHTML = d2;
diarypage1.innerHTML = d1;

savebutton.onclick = async function () {
    send("savediary", [diarypage1.value, diarypage2.value, userid]);
}
if (username != null) {
   title.innerText = username+"'s Diary";
}





