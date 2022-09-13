import './Login.css';

const Login = () => {

    return (
        <div className="Login">
            <h1>Login</h1><br /><br />
            <form>
                <label>Username</label><br/>
                <input
                    className="input"
                    type="text"
                /><br /><br />
                <label>Password</label><br />
                <input
                    className="input"
                    type="text"
                />
            </form>
        </div>
    );
}

export default Login;