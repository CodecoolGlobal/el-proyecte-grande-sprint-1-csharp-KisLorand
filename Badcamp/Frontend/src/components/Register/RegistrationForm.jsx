const RegistrationForm = ( { handleSubmit }) => {

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="username">New username</label><br />
            <input
                id="username"
                placeholder="Enter new username"
                type="text"
                name="newUsername"
                required
                autoFocus
            />

            <br /><br />

            <label htmlFor="password">New password</label><br />
            <input
                id="password"
                placeholder="Enter new password"
                type="password"
                name="newPassword"
                required
            /><br /><br />

            <button className="custom-btn" type="submit">Register</button><br /><br />
{/*            {errorMessage ? <p style={{ color: "red" }}>{errorMessage}</p> : null}*/}
        </form>
    );
}

export default RegistrationForm;