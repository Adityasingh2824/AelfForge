// helpers.js

// Function to validate contract name
export const isValidContractName = (name) => {
    // Regex to check for valid aelf contract name (alphanumeric, underscores, and starts with a letter)
    const nameRegex = /^[a-zA-Z][a-zA-Z0-9_]*$/;
    return nameRegex.test(name);
};

// Function to format error messages for the ErrorDisplay component
export const formatErrors = (errors) => {
    return errors.map((error) => ({
        line: error.line,
        message: error.message,
        hint: error.hint || '', // Include hint if available
    }));
};

// Function to format deployment parameters
export const formatDeploymentParameters = (parametersString) => {
    return parametersString.split(',').map(param => param.trim());
};

// Function to display a notification (snackbar)


