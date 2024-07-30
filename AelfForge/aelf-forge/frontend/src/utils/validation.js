// validation.js

// Function to validate contract name
export const validateContractName = (name) => {
    if (!name) {
        return 'Contract name is required';
    }
    
    // Regex to check for valid aelf contract name (alphanumeric, underscores, and starts with a letter)
    const nameRegex = /^[a-zA-Z][a-zA-Z0-9_]*$/;
    if (!nameRegex.test(name)) {
        return 'Invalid contract name. It must start with a letter and can only contain letters, numbers, and underscores.';
    }
    
    return null; // No error
};

// Function to validate contract description
export const validateContractDescription = (description) => {
    if (!description) {
        return 'Contract description is required';
    }

    if (description.length < 10) {
        return 'Description must be at least 10 characters long';
    }
    
    return null;
};

// Function to validate deployment parameters
export const validateDeploymentParameters = (parametersString) => {
    if (!parametersString) {
        return null; // Parameters are optional
    }
    
    const parameters = parametersString.split(',').map(param => param.trim());

    // You can add more specific validation rules here based on your contract's requirements
    // For example, checking the data type, length, or format of each parameter

    return null; // No errors (or add your custom error message here)
};
