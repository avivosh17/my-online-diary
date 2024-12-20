import { send } from "../utilities";

let usernameinput = document.querySelector("#usernameinput") as HTMLInputElement;
let passwordinput = document.querySelector("#passwordinput") as HTMLInputElement;
let submitbutton = document.querySelector("#submitbutton") as HTMLButtonElement;
let messagediv = document.querySelector("#messagediv") as HTMLInputElement;

submitbutton.onclick = async function () {

    let userid = await send("signup", [usernameinput.value, passwordinput.value]);

    if (userid != null) {
        localStorage.setItem("userid", userid);
        location.href = "/website/pages/index.html";
    }
    else {
        messagediv.innerText = "username is already taken"
    }
}