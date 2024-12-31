import { createSignal, type Component } from 'solid-js';

import { Button } from "~/components/ui/button"

import { useNavigate } from '@solidjs/router';

import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"

import { showToast, Toaster } from '~/components/ui/toast';

const RegisterPage: Component = () => {
    const navigate = useNavigate()

    const [username, setUsername] = createSignal("")
    const [password, setPassword] = createSignal("")
    const [responseCode, setResponseCode] = createSignal(0)

    function TryRegister() {
        if (username() !== "" && password() !== "") {
            fetch(`https://api.localhost/login/register?username=${username()}&password=${password()}`, {
                method: "POST"
            }).then((response) => {
                const statusCode = Number.parseInt(response.status.toString())
                setResponseCode(statusCode)
                switch (responseCode().toString().substring(0, 2)) {
                    case "20":
                        showToast({ title: "Register Successful", variant: "success" })
                        setTimeout(() => {
                            navigate("/loginpage")
                        }, 400);
                        break;

                    case "40":
                        showToast({ title: "Failed!", variant: "error" })
                        break;

                    case "0":
                        showToast({ title: "Debug", variant: "warning" })
                        break;
                }
            })
        }
    }

    return (
        <div>
            <TextField>
                <TextFieldLabel>Username: </TextFieldLabel>
                <TextFieldInput
                    onChange={e => setUsername(e.target.value)}
                    type='text'
                    required />
            </TextField>
            <TextField>
                <TextFieldLabel>Password: </TextFieldLabel>
                <TextFieldInput
                    onChange={e => setPassword(e.target.value)}
                    type='password'
                    required />
            </TextField>
            <Button type='submit' onClick={() => TryRegister()}>Register</Button>

            <Toaster />
        </div>
    )
}

export default RegisterPage