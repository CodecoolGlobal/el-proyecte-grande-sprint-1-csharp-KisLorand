const RegistrationForm = ( { handleSubmit, regError }) => {

    return (
        <form onSubmit={handleSubmit}>
            <input
                placeholder="*Username"
                type="text"
                name="newUsername"
                required
                autoFocus
            /><br /><br />

            <input
                placeholder="*Full name"
                type="text"
                name="newFullName"
                required
            /><br /><br />

            <label htmlFor="date" style={{ color: "red" }}>*Date of birth</label><br />
            <input
                id="date"
                type="date"
                name="newDateOfBirth"
                required
            /><br /><br />

            <input
                placeholder="*Password"
                type="password"
                name="newPassword"
                required
            /><br /><br />

            <input
                placeholder="*Confirm password"
                type="password"
                name="newPassword2"
                required
            /><br /><br />

            <button className="custom-btn" type="submit">Register</button><br /><br />
            {regError ? <p style={{ color: "red" }}>{regError}</p> : null}
        </form>
    );
}

export default RegistrationForm;