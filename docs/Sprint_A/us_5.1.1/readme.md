# US 5.1.1

## 1. Context

*As an Admin, I want to register new backoffice users (e.g., doctors, nurses, technicians, admins) via an out-of-band process, so that they can access the backoffice system with appropriate permissions.*

## 2. Requirements

### 2.1. Acceptance Criteria

- **5.1.1.1.** Backoffice users (e.g., doctors, nurses, technicians) are registered by an Admin via an internal process, not via self-registration.

- **5.1.1.2.** Admin assigns roles (e.g., Doctor, Nurse, Technician) during the registration process.

- **5.1.1.3.** Registered users receive a one-time setup link via email to set their password and activate their account.

- **5.1.1.4.** The system enforces strong password requirements for security.

- **5.1.1.5.** A confirmation email is sent to verify the user’s registration.

### 2.2. Dependencies

- This user story does not have dependencies on other user stories.

### 2.3. Forum Insights

>**Q1:** "Chapter 3.2 says that "Backoffice users are registered by the admin in the IAM through an out-of-band process.", but US 5.1.1 says that "Backoffice users are registered by an Admin via an internal process, not via self-registration.".
Can you please clarify if backoffice users registration uses the IAM system? And if the IAM system is the out-of-band process?"
>
>**A1:** "What this means is that backoffice users can not self-register in the system like the patients do. The admin must register the backoffice user. If you are using an external IAM (e.g., Google, Azzure, Linkedin, ...) the backoffice user must first create their account in the IAM provider and then pass the credential info to the admin so that the user account in the system is "linked" wit the external identity provider."

>**Q2:** "Can you clarify the username and email requirements?"
>
>**A2:** "The username is the "official" email address of the user. for backoffice users, this is the mechanographic number of the collaborator, e.g., D240003 or N190345, and the DNS domain of the system. For instance, Doctor Manuela Fernandes has email "D180023@myhospital.com". The system must allow for an easy configuration of the DNS domain (e.g., environment variable).
For patients, the username is the email address provided in the patient record and used as identity in the external IAM. for instance patient Carlos Silva has provided his email csilva98@gmail.com the first time he entered the hospital. That email address will be his username when he self-registers in the system."

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

*In this sections, the team should present the solution design that was adopted to solve the requirement. This should include, at least, a diagram of the realization of the functionality (e.g., sequence diagram), a class diagram (presenting the classes that support the functionality), the identification and rational behind the applied design patterns and the specification of the main tests used to validade the functionality.*

### 4.1. Sequence Diagram (Level 3 - Process View)

![Sequence Diagram](IMG/sequence-diagram-level-3.svg)

### 4.2. Testes

**Teste 1:** *Verifies that it is not possible to create an instance of the Example class with null values.*

```
@Test(expected = IllegalArgumentException.class)
public void ensureNullIsNotAllowed() {
	Example instance = new Example(null, null);
}
```

## 5. Implementation

*In this section the team should present, if necessary, some evidencies that the implementation is according to the design. It should also describe and explain other important artifacts necessary to fully understand the implementation like, for instance, configuration files.*

*It is also a best practice to include a listing (with a brief summary) of the major commits regarding this requirement.*

...

## 6. Integration/Demonstration

*In this section the team should describe the efforts realized in order to integrate this functionality with the other parts/components of the system*

*It is also important to explain any scripts or instructions required to execute an demonstrate this functionality*

## 7. Observations

*This section should be used to include any content that does not fit any of the previous sections.*

*The team should present here, for instance, a critical prespective on the developed work including the analysis of alternative solutioons or related works*

*The team should include in this section statements/references regarding third party works that were used in the development this work.*