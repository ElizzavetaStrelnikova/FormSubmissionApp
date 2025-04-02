<template>
    <form @submit.prevent="submitForm" class="contact-form">
        <h2>Contact Us</h2>

        <div class="form-group">
            <label for="name">Name:</label>
            <input type="text"
                   id="name"
                   v-model="formData.name"
                   @blur="validateField('name')"
                   :class="{ 'invalid': errors.name }">
            <span class="error-message" v-if="errors.name">{{ errors.name }}</span>
        </div>

        <div class="form-group">
            <label for="email">Email:</label>
            <input type="text"
                   id="email"
                   v-model="formData.email"
                   @blur="validateField('email')"
                   :class="{ 'invalid': errors.email }">
            <span class="error-message" v-if="errors.email">{{ errors.email }}</span>
        </div>

        <div class="form-group">
            <label>Contact Reason:</label>
            <select v-model="formData.reason" class="form-control">
                <option value="">Select a reason</option>
                <option value="question">Question</option>
                <option value="feedback">Feedback</option>
                <option value="complaint">Complaint</option>
            </select>
        </div>

        <div class="form-group">
            <label>Preferred Contact Method:</label>
            <div class="radio-group">
                <label>
                    <input type="radio" v-model="formData.contactMethod" value="email"> Email
                </label>
                <label>
                    <input type="radio" v-model="formData.contactMethod" value="phone"> Phone
                </label>
            </div>
        </div>

        <div class="form-group">
            <label for="date">Follow-up Date:</label>
            <input type="date" id="date" v-model="formData.followUpDate">
        </div>

        <div class="form-group">
            <label>
                <input type="checkbox" v-model="formData.newsletter"> Subscribe to newsletter
            </label>
        </div>

        <div class="form-group">
            <label for="message">Message:</label>
            <textarea id="message"
                      v-model="formData.message"
                      @blur="validateField('message')"
                      :class="{ 'invalid': errors.message }"></textarea>
            <span class="error-message" v-if="errors.message">{{ errors.message }}</span>
        </div>

        <button type="submit" :disabled="isSubmitting">
            {{ isSubmitting ? 'Submitting...' : 'Submit' }}
        </button>

        <div v-if="submitSuccess" class="success-message">
            Form submitted successfully!
        </div>
    </form>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios';

export default {
  setup() {
    const formData = ref({
      name: '',
      email: '',
      reason: '',
      contactMethod: 'email',
      followUpDate: '',
      newsletter: false,
      message: ''
    });

    const errors = ref({});
    const isSubmitting = ref(false);
    const submitSuccess = ref(false);

    const validateField = (field) => {
      errors.value[field] = '';

      if (field === 'name' && !formData.value.name.trim()) {
        errors.value.name = 'Name is required';
      }

      if (field === 'email') {
        if (!formData.value.email.trim()) {
          errors.value.email = 'Email is required';
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.value.email)) {
          errors.value.email = 'Please enter a valid email';
        }
      }

      if (field === 'message' && !formData.value.message.trim()) {
        errors.value.message = 'Message is required';
      }
    };

    const validateForm = () => {
      validateField('name');
      validateField('email');
      validateField('message');

      return !Object.values(errors.value).some(error => error);
    };

    const submitForm = async () => {
      if (!validateForm()) return;

      isSubmitting.value = true;
      submitSuccess.value = false;

      try {
          await axios.post('http://localhost:5182/api/formsubmission', {
          formType: 'contact',
          formData: formData.value
        });

        submitSuccess.value = true;
        // Reset form after successful submission
        formData.value = {
          name: '',
          email: '',
          reason: '',
          contactMethod: 'email',
          followUpDate: '',
          newsletter: false,
          message: ''
        };
      } catch (error) {
        console.error('Submission error:', error);
      } finally {
        isSubmitting.value = false;
      }
    };

    return {
      formData,
      errors,
      isSubmitting,
      submitSuccess,
      validateField,
      submitForm
    };
  }
};
</script>

<style scoped>
    .contact-form {
        max-width: 600px;
        margin: 0 auto;
        padding: 20px;
        background: #f9f9f9;
        border-radius: 8px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .form-group {
        margin-bottom: 15px;
    }

    label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
    }

    input[type="text"],
    input[type="email"],
    input[type="date"],
    textarea,
    select {
        width: 100%;
        padding: 8px;
        border: 1px solid #ddd;
        border-radius: 4px;
        box-sizing: border-box;
    }

    textarea {
        height: 100px;
    }

    .radio-group {
        display: flex;
        gap: 15px;
    }

        .radio-group label {
            display: flex;
            align-items: center;
            gap: 5px;
            font-weight: normal;
        }

    button {
        background-color: #4CAF50;
        color: white;
        padding: 10px 15px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        font-size: 16px;
    }

        button:disabled {
            background-color: #cccccc;
            cursor: not-allowed;
        }

        button:hover:not(:disabled) {
            background-color: #45a049;
        }

    .error-message {
        color: #d9534f;
        font-size: 0.85em;
        margin-top: 5px;
        display: block;
    }

    .success-message {
        color: #5cb85c;
        margin-top: 15px;
        font-weight: bold;
    }

    .invalid {
        border-color: #d9534f;
    }
</style>