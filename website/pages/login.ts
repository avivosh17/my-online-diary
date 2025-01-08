import { send } from "../utilities";

let usernameinput = document.querySelector("#usernameInput") as HTMLInputElement;
let passwordinput = document.querySelector("#passwordInput") as HTMLInputElement;
let submitbutton = document.querySelector("#submitButton") as HTMLButtonElement;
let messagediv = document.querySelector("#messageDiv") as HTMLDivElement;

submitbutton.onclick = async function () {
    let userId = await send("login", [usernameinput.value, passwordinput.value]) as string | null;

    if (userId != null) {
        localStorage.setItem("userId", userId);

        location.href = "index.html";
    }
    else {
        messagediv.innerText = "User does not exist.";
    }
}
submitbutton.onclick = async function () {

}