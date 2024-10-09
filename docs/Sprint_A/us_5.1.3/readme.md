# US 5.1.3 - As a Patient, I want to register in the healthcare application

## 1. Contexto

*As a Patient, I want to register in the healthcare application, so that I can create a user profile and book appointments online.*

## 2. Requirements

### 2.1. Acceptance Criteria

- **5.1.3.1.** Patients can self-register using the external IAM system.

- **5.1.3.2.** During registration, patients provide personal details (e.g., name, email, phone) and create a profile.

- **5.1.3.3.** The system validates the email address by sending a verification email with a confirmation link

- **5.1.3.4.** Patients cannot book appointments without completing the registration process.

### 2.2. Dependencies

- This user story does not have dependencies on other user stories.

### 2.3. Forum Insights

>**Q1:** "In IAM external system, if a patient is signed in with a google account and later uses other external system like Facebook, and both have different credentials, what happens?"
>
>**A1:** "assume the system only supports one IAM."

>**Q2:** ".."
>
>**A2:** "..."

>**Q3:** ".."
>
>**A3:** "..."

>**Q4:** ".."
>
>**A4:** "..."

>**Q5:** ".."
>
>**A5:** "..."

## 3. Analysis

### 3.1. Sequence Diagram of the System (Level 1 - Process View)

![Sequence Diagram of the System](IMG/system-sequence-diagram-level-1.svg)

### 3.1. Sequence Diagram of the System (Level 2 - Process View)

![Sequence Diagram of the System](IMG/system-sequence-diagram-level-2.svg)

## 4. Design

*In these sections, the team should present the solution design adopted to solve the requirement. This should include, at least, a diagram of the realization of the functionality (e.g., sequence diagram), a class diagram (presenting the classes that support the functionality), the identification and rational behind the applied design patterns and the specification of the main tests used to validade the functionality.*

### 4.1. Sequence Diagram (Level 3 - Process View)

![Sequence Diagram](IMG/sequence-diagram-level-3.svg)

### 4.2. Testes

**Test 1:** *Verifies that it is not possible to create an instance of the Example class with null values.*

```
@Test(expected = IllegalArgumentException.class)
public void ensureNullIsNotAllowed() {
	Example instance = new Example(null, null);
}
```

## 5. Implementation

*In this section, the team should present, if necessary, some evidence that the implementation is according to the design. It should also describe and explain other important artifacts necessary to fully understand the implementation like, for instance, configuration files.*

*It is also a best practice to include a listing (with a brief summary) of the major commits regarding this requirement.*

...

## 6. Integration/Demonstration

*In this section, the team should describe the efforts realized to integrate this functionality with the other parts/components of the system*

*It is also important to explain any scripts or instructions required to execute and demonstrate this functionality*

## 7. Observations

*This section should be used to include any content that does not fit any of the previous sections.*

*The team should present here, for instance, a critical perspective on the developed work including the analysis of alternative solutions or related works*

*The team should include in this section statements/references regarding third party works that were used in the development of this work.*