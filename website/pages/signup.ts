import { send } from "../utilities";

let usernameinput = document.querySelector("#usernameinput") as HTMLInputElement;
let passwordinput = document.querySelector("#passwordInput") as HTMLInputElement;
let submitbutton = document.querySelector("#submitbutton") as HTMLButtonElement;

submitbutton.onclick = async function ()
{
let userid = await send ("signup", [usernameinput.value, passwordinput.value]);

localStorage.setItem("userid", userid);

location.href = "/website/pages/index.html";
}