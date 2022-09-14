const LoginForm = ({ handleSubmit, errorMessage }) => {

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="username">Username</label><br />
            <input
                id="username"
                placeholder="Enter username"
                type="text"
                name="username"
                required
                autoFocus
            />

            <br /><br />

            <label htmlFor="password">Password</label><br />
            <input
                id="password"
                placeholder="Enter password"
                type="password"
                name="password"
                required
            /><br /><br />

            <button type="submit">Submit</button><br /><br />
            {errorMessage ? <p style={{ color: "red" }}>{errorMessage}</p> : null}
        </form>
    );
}

export default LoginForm;