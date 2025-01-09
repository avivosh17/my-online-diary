import { send } from "../utilities";

let usernameinput = document.querySelector("#usernameinput") as HTMLInputElement;
let passwordinput = document.querySelector("#passwordinput") as HTMLInputElement;
let submitbutton = document.querySelector("#submitbutton") as HTMLButtonElement;
let messagediv = document.querySelector("#messagediv") as HTMLDivElement;

submitbutton.onclick = async function () {
    let userId = await send("login", [usernameinput.value, passwordinput.value]) as string | null;

    if (userId != null) {
        localStorage.setItem("userid", userId);

        location.href = "diary.html";
    }
    else {
        messagediv.innerText = "User does not exist.";
    }
}